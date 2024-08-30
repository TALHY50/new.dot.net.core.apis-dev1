namespace Admin.App.Presentation.Routes;

public class CountryRoutes
{
    public const string GetCountryMethod = "GET";
    public const string GetCountryName = "countries";
    public const string GetCountryTemplate = "/countries";
    
    public const string GetCountryByIdMethod = "GET";
    public const string GetCountryByIdName = "country_by_id";
    public const string GetCountryByIdTemplate = "countries/id/{id}";
    
    public const string CreateCountryMethod = "POST";
    public const string CreateCountryName = "create_country";
    public const string CreateCountryTemplate = "/countries";
    
    public const string DeleteCountryMethod = "DELETE";
    public const string DeleteCountryName = "delete_country";
    public const string DeleteCountryTemplate = "/countries/{id}";
    
    public const string UpdateCountryMethod = "PUT";
    public const string UpdateCountryName = "update_country";
    public const string UpdateCountryTemplate = "/countries/{id}";
    
}