using HomeValuationBackend.Models;

namespace HomeValuationBackend.Managers
{
    public class HomeValuationManager
    {
        private readonly HomeValuationContext _context;

        public HomeValuationManager(HomeValuationContext context)
        {
            _context = context;
        }

        public IEnumerable<Home> GetAll()
        {
            IQueryable<Home> homesList = _context.Homes;
            return homesList.ToList();
        }

        public Home GetById(int id)
        {
            return _context.Homes.Find(id);
        }

        public double AvgSqmPriceInMunicipality(int municipalityId)
        {
            var homesInMunicipality = _context.Homes.Where(home => home.MunicipalityId == municipalityId && home.Price != 0 && home.SquareMeters != 0);

            double avgPricePerSquareMeter = homesInMunicipality.Average(home => (double)home.Price / (double)home.SquareMeters);

            double roundedAvgPrice = Math.Round(avgPricePerSquareMeter, 0);
            return roundedAvgPrice;
        }

        public double CalculateSingleHome(int municipalityId, int squareMeters, int constructionYear, string energyLabel)
        {
            double avgPricePerSquareMeter = AvgSqmPriceInMunicipality(municipalityId);
            double totalPrice = avgPricePerSquareMeter * squareMeters;

            double adjustedPrice = totalPrice;

            if (constructionYear >= 2013)
            {
                if (municipalityId == 1)
                    adjustedPrice *= 1.17;
                else if (municipalityId == 2)
                    adjustedPrice *= 1.34;
            }
            else if (constructionYear >= 2007 && constructionYear <= 2012)
            {
                if (municipalityId == 1)
                    adjustedPrice *= 1.10;
                else if (municipalityId == 2)
                    adjustedPrice *= 1.34;
            }
            else if (constructionYear >= 1999 && constructionYear <= 2006)
            {
                if (municipalityId == 1)
                    adjustedPrice *= 1.01;
                else if (municipalityId == 2)
                    adjustedPrice *= 1.17;
            }
            else if (constructionYear >= 1979 && constructionYear <= 1998)
            {
                if (municipalityId == 1)
                    adjustedPrice *= 0.78;
                else if (municipalityId == 2)
                    adjustedPrice *= 1;
            }
            else if (constructionYear >= 1973 && constructionYear <= 1978)
            {
                if (municipalityId == 1)
                    adjustedPrice *= 0.82;
                else if (municipalityId == 2)
                    adjustedPrice *= 0.96;
            }
            else if (constructionYear >= 1961 && constructionYear <= 1972)
            {
                if (municipalityId == 1)
                    adjustedPrice *= 0.86;
                else if (municipalityId == 2)
                    adjustedPrice *= 0.87;
            }
            else if (constructionYear >= 1951 && constructionYear <= 1960)
            {
                if (municipalityId == 1)
                    adjustedPrice *= 1.02;
                else if (municipalityId == 2)
                    adjustedPrice *= 0.93;
            }
            else if (constructionYear >= 1931 && constructionYear <= 1950)
            {
                if (municipalityId == 1)
                    adjustedPrice *= 1.27;
                else if (municipalityId == 2)
                    adjustedPrice *= 0.89;
            }
            else if (constructionYear >= 1890 && constructionYear <= 1930)
            {
                if (municipalityId == 1)
                    adjustedPrice *= 1.0;
                else if (municipalityId == 2)
                    adjustedPrice *= 1.21;
            }
            else if (constructionYear < 1890)
            {
                if (municipalityId == 1)
                    adjustedPrice *= 0.88;
                else if (municipalityId == 2)
                    adjustedPrice *= 1.03;
            }

            switch (energyLabel)
            {
                case "A":
                    adjustedPrice *= 1.21;
                    break;
                case "B":
                    adjustedPrice *= 1.17;
                    break;
                case "C":
                    adjustedPrice *= 1.1;
                    break;
                case "D":
                    adjustedPrice *= 1;
                    break;
                case "E":
                    adjustedPrice *= 0.93;
                    break;
                case "F":
                    adjustedPrice *= 0.87;
                    break;
                case "G":
                    adjustedPrice *= 0.75;
                    break;
                default:
                    adjustedPrice *= 1;
                    break;
            }

            double roundedAdjustedPrice = Math.Round(adjustedPrice, 0);
            return roundedAdjustedPrice;
        }
    }
}
