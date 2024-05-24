using MAUISql.Data;

namespace CashCrew.Maui.Services
{
    public class SeedDataService
    {
        private readonly DatabaseContext _dbContext;
        public SeedDataService(DatabaseContext dbContext)
            => _dbContext = dbContext;

        public async Task SeedDataAsync()
        {
            if (await _dbContext.FindAsync<ExpenseCategory>("Entertainment") is not null)
                return;

            var expenseCategories = new List<ExpenseCategory>
            {
                new ExpenseCategory("Food and Drinks"),
                new ExpenseCategory("Entertainment"),
                new ExpenseCategory("Transport"),
                new ExpenseCategory("Experiences"),
                new ExpenseCategory("Accomodation"),
                new ExpenseCategory("Tips"),
                new ExpenseCategory("Refund"),
                new ExpenseCategory("Others")
            };

            var locationCategories = new List<LocationCategory>
            {
                new LocationCategory("relax", "images/relax-travel.png"),
                new LocationCategory("culture", "images/culture-travel.png"),
                new LocationCategory("nature", "images/nature-travel.png"),
                new LocationCategory("party", "images/party-travel.png")
            };

            foreach (var category in expenseCategories)
                await _dbContext.AddItemAsync<ExpenseCategory>(category);
            foreach (var location in locationCategories)
                await _dbContext.AddItemAsync<LocationCategory>(location);
        }
    }
}
