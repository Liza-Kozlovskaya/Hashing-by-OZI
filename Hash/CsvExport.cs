using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;

namespace Jitbit.Utils
{
	public class CsvExport
	{
        /// <summary>
        /// ����� ��������� ������������� ������ ���� ��������
		/// </summary>
		List<string> _fields = new List<string>();

		/// <summary>
		/// ������ �����
		/// </summary>
		List<Dictionary<string, object>> _rows = new List<Dictionary<string, object>>();

		/// <summary>
		/// ������� ������
		/// </summary>
		Dictionary<string, object> _currentRow { get { return _rows[_rows.Count - 1]; } }

        /// <summary>
        /// ������, ������������ ��� ���������� �������� �� ������
        /// </summary>
        private readonly string _columnSeparator;

		/// <summary>
		/// ����������� �� �������
		/// </summary>
		private readonly bool _includeColumnSeparatorDefinitionPreamble;


        /// <summary>
        // �������� �� ���������, ������� ���������, ����� ����������� �������� ������������ � ������
        /// </summary>
        public CsvExport(string columnSeparator=",", bool includeColumnSeparatorDefinitionPreamble=true)
		{
			_columnSeparator = columnSeparator;
			_includeColumnSeparatorDefinitionPreamble = includeColumnSeparatorDefinitionPreamble;
		}

        /// <summary>
        /// �������� � ���� �������
        /// </summary>
        public object this[string field]
		{
			set
			{
				
				if (!_fields.Contains(field)) _fields.Add(field);
				_currentRow[field] = value;
			}
		}

		public void AddRow()
		{
			_rows.Add(new Dictionary<string, object>());
		}

		/// <summary>
		/// �������� � ������
		/// </summary>
		public void AddRows<T>(IEnumerable<T> list)
		{
			if (list.Any())
			{
				foreach (var obj in list)
				{
					AddRow();
					var values = obj.GetType().GetProperties();
					foreach (var value in values)
					{
						this[value.Name] = value.GetValue(obj, null);
					}
				}
			}
		}

        /// <summary>
        /// ����������� �������� � ��, ��� ��� ������ ���������� � ����� csv
        /// </summary>
        public static string MakeValueCsvFriendly(object value, string columnSeparator=",")
		{
			if (value == null) return "";
			if (value is INullable && ((INullable)value).IsNull) return "";
			if (value is DateTime)
			{
				if (((DateTime)value).TimeOfDay.TotalSeconds == 0)
					return ((DateTime)value).ToString("yyyy-MM-dd");
				return ((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss");
			}
			string output = value.ToString().Trim();
			if (output.Contains(columnSeparator) || output.Contains("\"") || output.Contains("\n") || output.Contains("\r"))
				output = '"' + output.Replace("\"", "\"\"") + '"';

			if (output.Length > 30000) //��������� ������ ��� ������� ������
			{
				if (output.EndsWith("\""))
				{
					output = output.Substring(0, 30000);
					if(output.EndsWith("\"") && !output.EndsWith("\"\"")) 
						output += "\""; 
					output += "\"";
				}
				else
					output = output.Substring(0, 30000);
			}
			return output;
		}

        /// <summary>
        /// ������� ��� ������ � ���� CSV(������� 1 ������ �� ���)
        /// </summary>
        private IEnumerable<string> ExportToLines()
		{
			if (_includeColumnSeparatorDefinitionPreamble) yield return "sep=" + _columnSeparator;

			// ���������
			yield return string.Join(_columnSeparator, _fields.Select(f => MakeValueCsvFriendly(f, _columnSeparator)));

			// ������
			foreach (Dictionary<string, object> row in _rows)
			{
				foreach (string k in _fields.Where(f => !row.ContainsKey(f)))
				{
					row[k] = null;
				}
				yield return string.Join(_columnSeparator, _fields.Select(field => MakeValueCsvFriendly(row[field], _columnSeparator)));
			}
		}

        /// <summary>
        /// ����� ���� ����� � ���� CSV
        /// </summary>
        public string Export()
		{
			StringBuilder sb = new StringBuilder();

			foreach (string line in ExportToLines())
			{
				sb.AppendLine(line);
			}

			return sb.ToString();
		}

		/// <summary>
		/// ����� � ����
		/// </summary>
		public void ExportToFile(string path)
		{
			File.WriteAllLines(path, ExportToLines(), Encoding.UTF8);
		}

		/// <summary>
		/// ����� ����� UTF8 ������
		/// </summary>
		public byte[] ExportToBytes()
		{
			var data = Encoding.UTF8.GetBytes(Export());
			return Encoding.UTF8.GetPreamble().Concat(data).ToArray();
		}
	}
}