namespace DesafioProjetoHospedagem.Extensions
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// Métodos de extensão da classe Enum
    /// </summary>
    public static class EnumExtension
    {
        /// <summary>
        /// Recupera a descrição do valor selecionado na enum
        /// </summary>
        /// <param name="value">Valor selecionado na enum</param>
        /// <returns>A descrição do valor selecionado na enum</returns>
        static public String GetDescription(this Enum value)
        {
            ArgumentNullException.ThrowIfNull(value);
            var field = value.GetType().GetField(value.ToString());
            if (field == null)
                return value.ToString();

            var attributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
            {
                return attribute.Description;
            }

            return value.ToString();
        }
    }
}
