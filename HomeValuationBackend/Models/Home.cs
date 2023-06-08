namespace HomeValuationBackend.Models
{
    public class Home
    {
        private int _id;

        public int Id
        {
            get => _id;
            set
            {
                _id = value;
            }
        }

        private int _municipalityId;

        public int MunicipalityId
        {
            get => _municipalityId;
            set
            {
                _municipalityId = value;
            }
        }

        private int _price;

        public int Price
        {
            get => _price;
            set
            {
                _price = value;
            }
        }

        private int _squareMeters;

        public int SquareMeters
        {
            get => _squareMeters;
            set
            {
                _squareMeters = value;
            }
        }

        private int? _constructionYear;

        public int? ConstructionYear
        {
            get => _constructionYear;
            set
            {
                _constructionYear = value;
            }
        }

        private string? _energyLabel;

        public string? EnergyLabel
        {
            get => _energyLabel;
            set
            {
                _energyLabel = value;
            }
        }

        public int AvgKvmPrice()
        {
            return (Price / SquareMeters);
        }

    }
}
