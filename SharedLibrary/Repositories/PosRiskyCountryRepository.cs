using System.Linq.Expressions;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using SharedLibrary.Interfaces;
using SharedLibrary.Interfaces.Repositories;
using SharedLibrary.Models;

namespace SharedLibrary.Repositories;

public class PosRiskyCountryRepository : GenericRepository<PosRiskyCountry>, IPosRiskyCountryRepository
{
    const string COUNTRY_CODE_FOR_ALL = "0";
    private readonly ILogger<object> _logger;
    private readonly ApplicationDbContext _context;
    private readonly IUnitOfWork _unitOfWork;

    public PosRiskyCountryRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    
    public List<PosRiskyCountry> GetRiskyCountries(Dictionary<string, object>? filters , string[]? columns =null)
    {
        var query = _context.PosRiskyCountries.AsQueryable();

        if (filters != null)
        {
            if (filters.ContainsKey("pos_id") && filters["pos_id"] != null)
            {
                if (filters["pos_id"] is int[] posIds)
                {
                    query = query.Where(r => posIds.Contains(r.PosId));
                }
                else if (filters["pos_id"] is int posId)
                {
                    query = query.Where(r => r.PosId == posId);
                }
            }

            if (filters.ContainsKey("country_code") && filters["country_code"] != null)
            {
                var countryCode = filters["country_code"].ToString();

                query = query.Where(r => r.CountryCode == countryCode || r.CountryCode == COUNTRY_CODE_FOR_ALL);
            }

            if (filters.ContainsKey("status") && filters["status"] != null)
            {
                var status =Convert.ToSByte(filters["status"].ToString());

                query = query.Where(r => r.Status == status);
            }
        }

        if (columns != null)
        {
            // Apply column selection if specified
            query = query.Select(CreateProjection<PosRiskyCountry>(columns));
        }

        return query.ToList();
    }

    private static Expression<Func<T, T>> CreateProjection<T>(string[] columns)
    {
        var parameter = Expression.Parameter(typeof(T));
        var bindings = columns
            .Select(column => Expression.PropertyOrField(parameter, column))
            .Select(property => Expression.Bind(property.Member, property))
            .OfType<MemberBinding>();

        var newExpression = Expression.New(typeof(T));
        var memberInit = Expression.MemberInit(newExpression, bindings);

        return Expression.Lambda<Func<T, T>>(memberInit, parameter);
    }


    public PosRiskyCountry? CheckAndGetCommissionForRiskyCountryCard(
        int posId, 
        string cardCountryCode, 
        IEnumerable<PosRiskyCountry>? posRiskyCountriesCollection = null)
    {
        PosRiskyCountry? commissionsData;

        if (posRiskyCountriesCollection == null || !posRiskyCountriesCollection.Any())
        {
            commissionsData =_context.PosRiskyCountries
                .Where(c => c.PosId == posId)
                .Where(c => c.CountryCode == cardCountryCode || c.CountryCode == COUNTRY_CODE_FOR_ALL)
                .FirstOrDefault();
        }
        else
        {
            commissionsData = posRiskyCountriesCollection
                .Where(c => c.PosId == posId)
                .Where(c => c.CountryCode == cardCountryCode || c.CountryCode == COUNTRY_CODE_FOR_ALL)
                .FirstOrDefault();
        }

        _logger.LogInformation(JsonSerializer.Serialize(new
        {
            action = "CHECK_AND_GET_COMMISSION_FOR_RISKY_COUNTRY_CARD",
            pos_id = posId,
            card_country_code = cardCountryCode,
            pos_risky_countries_collection = posRiskyCountriesCollection,
            commissions_data = commissionsData
        }));

        return commissionsData;
    }

}