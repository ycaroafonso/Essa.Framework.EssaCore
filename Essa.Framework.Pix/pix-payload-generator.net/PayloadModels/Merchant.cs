using Essa.Framework.Util.Extensions;
namespace pix_payload_generator.net.Models.PayloadModels
{
    public class Merchant
    {
        public Merchant(string _name, string _city)
        {
            if (!string.IsNullOrEmpty(_name) && _name.Length > 25) _name = _name.Substring(0, 25);
            Name = _name.RemoveAcentos();
            City = _city;
        }

        /// <summary>
        /// Nome do titular da conta
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Cidade do titular da conta
        /// </summary>
        public string City { get; private set; }
    }
}
