namespace RSAManager.Helpers
{
    public static class RSAKeyValue
    {
        public static RSAPublicKey ToPublicKey(string xml)
        {
            return XMLHelper.FromXML<RSAPublicKey>(xml);
        }

        public static RSAPrivateKey ToPrivateKey(string xml)
        {
            return XMLHelper.FromXML<RSAPrivateKey>(xml);
        }
    }
}
