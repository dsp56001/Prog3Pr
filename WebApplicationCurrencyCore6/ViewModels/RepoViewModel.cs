using Currency;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplicationCurrencyCore6.ViewModels
{
    public enum Locale
    {
        US,
        UK
    }

    public struct ConvertEnum
    {
        public int Value
        {
            get;
            set;
        }
        public String Text
        {
            get;
            set;
        }
    }

    public class RepoViewModel
    {
        ICurrencyRepo repo;
        List<ConvertEnum> LocalizationEnum;
        public List<SelectListItem > LocalizationSelectList;

        public RepoViewModel(ICurrencyRepo repo)
        {
            this.repo = repo;
            LocalizationEnum = new List<ConvertEnum>();
            foreach (Locale lo in Enum.GetValues(typeof(Locale)))
            {
                LocalizationEnum.Add(new ConvertEnum
                {
                    Value = (int)lo,
                    Text = lo.ToString()
                });
            }
            LocalizationSelectList = new List<SelectListItem>();
            foreach(ConvertEnum lo in LocalizationEnum)
            {
                LocalizationSelectList.Add(new SelectListItem(lo.Text,lo.Value.ToString()));
            }
        }

        public double TotalValue
        {
            get { return repo.TotalValue(); }
        }

        public void MakeChange(Double Amount)
        {
            repo = repo.MakeChange(Amount);
        }

        public List<ICurrency> Coins
        {
            get { return repo.Coins; }
        }
    }
}
