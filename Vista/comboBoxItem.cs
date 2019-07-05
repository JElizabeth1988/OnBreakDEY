namespace Vista
{
    internal class comboBoxItem
    {
        public int id { get; set; }
        public string descripcion { get; set; }


        public comboBoxItem()
        {

        }

        public override string ToString()
        {
            return descripcion.Trim();
        }
    }
  
}