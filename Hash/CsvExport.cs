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
        /// Чтобы сохранить упорядоченный список имен столбцов
		/// </summary>
		List<string> _fields = new List<string>();

		/// <summary>
		/// Список строк
		/// </summary>
		List<Dictionary<string, object>> _rows = new List<Dictionary<string, object>>();

		/// <summary>
		/// Текущая строка
		/// </summary>
		Dictionary<string, object> _currentRow { get { return _rows[_rows.Count - 1]; } }

        /// <summary>
        /// Строка, используемая для разделения столбцов на выходе
        /// </summary>
        private readonly string _columnSeparator;

		/// <summary>
		/// Разделитель на столбцы
		/// </summary>
		private readonly bool _includeColumnSeparatorDefinitionPreamble;


        /// <summary>
        // Включить ли преамбулу, которая объявляет, какой разделитель столбцов используется в выводе
        /// </summary>
        public CsvExport(string columnSeparator=",", bool includeColumnSeparatorDefinitionPreamble=true)
		{
			_columnSeparator = columnSeparator;
			_includeColumnSeparatorDefinitionPreamble = includeColumnSeparatorDefinitionPreamble;
		}

        /// <summary>
        /// Значение в этом столбце
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
		/// Добавить в список
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
        /// Преобразует значение в то, как оно должно выводиться в файле csv
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

			if (output.Length > 30000) //обрезание строки при больших числах
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
        /// Выводит все строки в виде CSV(выводит 1 строку за раз)
        /// </summary>
        private IEnumerable<string> ExportToLines()
		{
			if (_includeColumnSeparatorDefinitionPreamble) yield return "sep=" + _columnSeparator;

			// Заголовок
			yield return string.Join(_columnSeparator, _fields.Select(f => MakeValueCsvFriendly(f, _columnSeparator)));

			// Строка
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
        /// Вывод всех строк в виде CSV
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
		/// Вывод в файл
		/// </summary>
		public void ExportToFile(string path)
		{
			File.WriteAllLines(path, ExportToLines(), Encoding.UTF8);
		}

		/// <summary>
		/// Вывод ввиде UTF8 байтов
		/// </summary>
		public byte[] ExportToBytes()
		{
			var data = Encoding.UTF8.GetBytes(Export());
			return Encoding.UTF8.GetPreamble().Concat(data).ToArray();
		}
	}
}