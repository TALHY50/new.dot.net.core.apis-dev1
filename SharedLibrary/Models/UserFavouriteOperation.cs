using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class UserFavouriteOperation
{
    public int Id { get; set; }

    public int UserId { get; set; }

    /// <summary>
    /// user id of selected favourite person
    /// </summary>
    public int FavouriteUserId { get; set; }

    /// <summary>
    /// 1 = send money, 2 = request money, 3 = withdrawal, 4 = bill payment
    /// </summary>
    public sbyte OperationType { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? GsmNumber { get; set; }

    public int? CurrencyId { get; set; }

    public string? Iban { get; set; }

    public int? BankStaticId { get; set; }

    /// <summary>
    /// api request input params
    /// </summary>
    public string? Data { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
