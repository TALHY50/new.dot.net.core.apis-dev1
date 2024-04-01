using SharedLibrary.Interfaces;
using SharedLibrary.Interfaces.Repositories;
using SharedLibrary.Models;
using SharedLibrary.Services;

namespace SharedLibrary.Repositories
{
    public class CCBlockListsRepository : GenericRepository<CCBlockList>, ICcBlockListsRepository
    {
        public static string GetLast(string source, int tailLength)
        {
            if (tailLength >= source.Length)
                return source;
            return source.Substring(source.Length - tailLength);
        }
        public CCBlockListsRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>
        /// Check whether the Credit card is blocked or not as per card_no and marchant_id.
        /// If Blocked credit card type is FULL_CARD, then the card hash have to match from FullCardBlockLists.
        /// </summary>
        public bool IsCardBlocked(string card_no, int merchant_id = 0)
        {
            // DB::enableQueryLog();
            bool result = false;

            if (!string.IsNullOrEmpty(card_no))
            {
                var currenctTime = DateTime.Now;
                var firstPart = card_no.Substring(0, 6);
                var lastPart = GetLast(card_no,4);
                var statusList = new List<int> { CCBlockList.BLOCKED, CCBlockList.BLOCKED_TO_UNBLOCK };
                var typeList = new List<int> { CCBlockList.TYPE_CARD, CCBlockList.TYPE_FULL_CARD };

                var blockCcObj = UnitOfWork.ApplicationDbContext.CcBlockLists.FirstOrDefault(c => ((c.CardNo ?? "").StartsWith(firstPart) && (c.CardNo ?? "").EndsWith(lastPart)
                        && statusList.Contains(Convert.ToInt32(c.Status))
                        && typeList.Contains(Convert.ToInt32(c.Type)))
                    ||
                    ((c.CardNo ?? "").StartsWith(firstPart)
                     && statusList.Contains(Convert.ToInt32(c.Status))
                     && c.Type == CCBlockList.TYPE_BIN
                    )
                    && (c.BlockedFrom < currenctTime && c.BlockedTo > currenctTime)
                    && (c.MerchantId == 0 || c.MerchantId == merchant_id));

                //    // dd(DB::getQueryLog());
                if (blockCcObj != null)
                {
                    if (blockCcObj.Type == CCBlockList.TYPE_FULL_CARD)
                    {
                        FullCardBlockList? fullCard = UnitOfWork.ApplicationDbContext.FullCardBlockLists.FirstOrDefault(s => s.CcBlockListId == blockCcObj.Id);
                        if (fullCard != null && fullCard.HashedCard != Cryptographer.HashSHA256(card_no))
                        {
                            result = false;
                        }
                        else
                        {
                            result = true;
                        }
                    }
                    else
                    {
                        result = true;
                    }
                }
            }
            return result;
        }
    }
}
