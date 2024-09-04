namespace IMT.App.Presentation.Routes;

public class CountryRoutes
{
    public const string GetCountryMethod = "GET";
    public const string GetCountryName = "countries";
    public const string GetCountryTemplate = "/v1/money-transfer/countries";

    public const string GetCountryByIdMethod = "GET";
    public const string GetCountryByIdName = "get_country_by_id";
    public const string GetCountryByIdTemplate = "/v1/money-transfer/countries/{id}";

    public const string CreateCountryMethod = "POST";
    public const string CreateCountryName = "create_country";
    public const string CreateCountryTemplate = "/v1/money-transfer/countries";

    public const string DeleteCountryMethod = "DELETE";
    public const string DeleteCountryName = "delete_country_by_id";
    public const string DeleteCountryTemplate = "/v1/money-transfer/countries/{id}";

    public const string UpdateCountryMethod = "PUT";
    public const string UpdateCountryName = "update_country_by_id";
    public const string UpdateCountryTemplate = "/v1/money-transfer/countries/{id}";

}