namespace IMT.App.Presentation.Routes;

public class CountryRoutes
{
    public const string GetCountryMethod = "GET";
    public const string GetCountryName = "countries";
    public const string GetCountryTemplate = "/money-transfer/countries";

    public const string GetCountryByIdMethod = "GET";
    public const string GetCountryByIdName = "get_country_by_id";
    public const string GetCountryByIdTemplate = "/money-transfer/countries/{id}";

    public const string CreateCountryMethod = "POST";
    public const string CreateCountryName = "create_country";
    public const string CreateCountryTemplate = "/money-transfer/countries";

    public const string DeleteCountryMethod = "DELETE";
    public const string DeleteCountryName = "delete_country_by_id";
    public const string DeleteCountryTemplate = "/money-transfer/countries/{id}";

    public const string UpdateCountryMethod = "PUT";
    public const string UpdateCountryName = "update_country_by_id";
    public const string UpdateCountryTemplate = "/money-transfer/countries/{id}";

}