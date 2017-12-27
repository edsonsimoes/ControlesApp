namespace ControlesAppCross.Models
{
    public class Item : BaseDataObject
	{

        string image = string.Empty;
        public string pathImage
        {
            get { return image; }
            set { SetProperty(ref image, value); }
        }

        string text = string.Empty;
		public string Text
		{
			get { return text; }
			set { SetProperty(ref text, value); }
		}

		string description = string.Empty;
		public string Description
		{
			get { return description; }
			set { SetProperty(ref description, value); }
		}
	}
}
