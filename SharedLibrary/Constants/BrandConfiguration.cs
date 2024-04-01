using DotNetEnv;

namespace SharedLibrary.Constants
{
    public static class Brand
    {
        public static readonly string name = Env.GetString("BRAND_NAME");
        public static readonly string name_code = Env.GetString("BRAND_NAME_CODE");
        public static readonly string logo = Env.GetString("BRAND_LOGO_PATH", "images/brand/sipay/logo.png");
        public static readonly string logo_2 = Env.GetString("BRAND_LOGO_2_PATH", "images/brand/sipay/logo2.png");
        public static readonly string logo_white = Env.GetString("BRAND_LOGO_WHITE_PATH", "images/brand/sipay/logo_white.png");
        public static readonly string logo_v_pos = string.Concat("assets/brand/", Env.GetString("BRAND_NAME_CODE"), "/logo_v_pos.png");
        public static readonly string logo_v_pos_white = string.Concat("assets/brand/", Env.GetString("BRAND_NAME_CODE"), "/logo_v_pos_white.png");
        public static readonly string favicon = Env.GetString("BRAND_FAVICON", "images/brand/sipay/favicon.png");
        public static readonly string base_app_url = Env.GetString("BASE_APP_URL");
        public static readonly string provisioning_url = Env.GetString("PROVISIONING_URL");
        public static readonly string support_url = Env.GetString("SUPPORT_URL", "");
        public static readonly string tax_number = Env.GetString("TAX_NUMBER", "");
        public static readonly string tax_office = Env.GetString("TAX_OFFICE", "");
        public static readonly string tax_office_code = Env.GetString("TAX_OFFICE_CODE", "");
        public static readonly string api_docs_link = Env.GetString("API_DOCS_LINK", "");
        public static readonly Dictionary<string, string> styles = new Dictionary<string, string> {
            { "colors" ,  Env.GetString("COLORS_CSS", "public/css/colors/sipay.css") },
            { "decorative_img" ,  Env.GetString("LOGIN_DECORATIVE_IMG", "public/assets/images/pic.png") }
        };
        public static readonly Dictionary<string, string> contact_info = new Dictionary<string, string> {
            { "phone_number" ,  Env.GetString("INFO_PHONE_NUMBER") },
            { "full_phone_number" ,  Env.GetString("FULL_PHONE_NUMBER") },
            {"email" ,  Env.GetString("INFO_EMAIL", "") },
            {"company_full_name" ,  Env.GetString("COMPANY_FULL_NAME") },
            {"company_full_name_en" ,  Env.GetString("COMPANY_FULL_NAME_EN") },
            {"address_line_1" ,  Env.GetString("COMPANY_ADDRESS_LINE_1") },
            {"address_line_2" ,  Env.GetString("COMPANY_ADDRESS_LINE_2") },
            {"website" ,  Env.GetString("COMPANY_WEBSITE") },
            {"mersis_no" ,  Env.GetString("COMPANY_MERSIS_NO") },
            {"kep_address" ,  Env.GetString("COMPANY_KEP_ADDRESS") },
            {"limits_and_fees_link_tr" ,  Env.GetString("LIMITS_AND_FEES_LINK_TR") },
            {"limits_and_fees_link_en" ,  Env.GetString("LIMITS_AND_FEES_LINK_EN")}
        };

        public static readonly Dictionary<string, string> social_media = new Dictionary<string, string> {
            {"facebook" ,  Env.GetString("COMPANY_FACEBOOK") },
            {"twitter" ,  Env.GetString("COMPANY_TWITTER") },
            {"instagram" ,  Env.GetString("COMPANY_INSTAGRAM") },
            {"linkedin" ,  Env.GetString("COMPANY_LINKEDIN") },
            {"youtube" ,  Env.GetString("COMPANY_YOUTUBE", "#") }
        };
        public static readonly Dictionary<string, string> emails = new Dictionary<string, string> {
            {"compliance" ,  Env.GetString("COMPLIANCE_EMAIL") },
            {"operations" ,  Env.GetString("OPERATIONS_EMAIL") },
            {"sales" ,  Env.GetString("SALES_EMAIL") },
            {"support" ,  Env.GetString("SUPPORT_EMAIL") },
            {"support_tr" ,  Env.GetString("SUPPORT_EMAIL_TR") }
        };




    }

    public class BrandConfiguration
    {
        public static bool QnbExtraPfRecordsParams()
        {
            string brandCode = Brand.name_code;
            string[] brandList =
            {
                Constants.BRAND_NAME_CODE_LIST["HP"],
                Constants.BRAND_NAME_CODE_LIST["QP"],
                Constants.BRAND_NAME_CODE_LIST["QP_TENANT"]
            };
            return brandList.Contains(brandCode);
        }

        public static bool IsAllowIpBlock()
        {
            string brandCode = Brand.name_code;
            string[] brandList =
            {
                Constants.BRAND_NAME_CODE_LIST["VP"],
            };
            return brandList.Contains(brandCode);
        }

        public static bool AllowedMultiplePosCampaignCategory()
        {
            var brand_code = Brand.name_code;
            var allow_list = new List<string>();
            //allow_list.Add(Constants.BRAND_NAME_CODE_LIST["SP"]);

            return allow_list.Contains(brand_code);
        }

        //confusion
        public static bool AllowDifferentCOTForRiskyCountries()
        {
            return false;
            string brand_code = Brand.name_code;
            List<string> brand_list = Constants.BRAND_NAME_CODE_LIST.Values.ToList();
            return brand_list.Contains(brand_code);
        }

        public static bool IsBrandForFastpayFraudService()
        {
            throw new NotImplementedException();
        }

        internal static bool AddChargeToSenderInB2BPayment()
        {
            string brandCode = Brand.name_code;
            List<string> brandList = new List<string>
            {
                Constants.BRAND_NAME_CODE_LIST["SP"]
            };
            return brandList.Contains(brandCode);
        }

        public static bool IsDisableSSLverify()
        {
            string brandCode = Brand.name_code;
            List<string> brandList = new List<string>
            {
                Constants.BRAND_NAME_CODE_LIST["PL"]
            };
            return brandList.Contains(brandCode);
        }

        internal static bool AllowCommissionFromSender()
        {
            string brandCode = Brand.name_code;
            List<string> brandList = new List<string>
            {
                Constants.BRAND_NAME_CODE_LIST["PP"],
                Constants.BRAND_NAME_CODE_LIST["YP"],
                Constants.BRAND_NAME_CODE_LIST["PC"],
                Constants.BRAND_NAME_CODE_LIST["SR"],
                Constants.BRAND_NAME_CODE_LIST["AP"],
                Constants.BRAND_NAME_CODE_LIST["PN"],
                Constants.BRAND_NAME_CODE_LIST["FL"],
                Constants.BRAND_NAME_CODE_LIST["HP"],
                Constants.BRAND_NAME_CODE_LIST["QP"],
                Constants.BRAND_NAME_CODE_LIST["QP_TENANT"],
                Constants.BRAND_NAME_CODE_LIST["DP"],
                Constants.BRAND_NAME_CODE_LIST["PL"]
            };
            return brandList.Contains(brandCode);
        }

        public static bool IsBrandForWalletValidationForRefundCommissionDeduction()
        {
            string brandCode = Brand.name_code;
            List<string> brandList = new List<string>
            {
                Constants.BRAND_NAME_CODE_LIST["PP"],
                Constants.BRAND_NAME_CODE_LIST["YP"],
                Constants.BRAND_NAME_CODE_LIST["PC"],
                Constants.BRAND_NAME_CODE_LIST["SR"],
                Constants.BRAND_NAME_CODE_LIST["AP"],
                Constants.BRAND_NAME_CODE_LIST["PN"],
                Constants.BRAND_NAME_CODE_LIST["FL"],
                Constants.BRAND_NAME_CODE_LIST["HP"],
                Constants.BRAND_NAME_CODE_LIST["QP"],
                Constants.BRAND_NAME_CODE_LIST["QP_TENANT"],
                Constants.BRAND_NAME_CODE_LIST["DP"],
                Constants.BRAND_NAME_CODE_LIST["PL"]
            };
            return brandList.Contains(brandCode);
        }

        public static int GetSurnameLength()
        {
            var brand_code = Brand.name_code;
            var length = 30;

            var brand_list = new string[]
            {
                !Constants.BRAND_NAME_CODE_LIST.ContainsKey("FP") ? "" : Constants.BRAND_NAME_CODE_LIST["FP"]
            };

            if (brand_list.Contains(brand_code))
            {
                length = 90;
            }

            return length;
        }

        public static bool Is3DModelCompatibleApi(string? api_name)
        {
            string[] list = new string[]
            {
                "PAY_3D",
                "PAY_SMART_3D"
            };

            return list.Contains(api_name);
        }

        public static bool IsInsurancePaymentCompatibleApi(string? api_name)
        {
            string[] list = new string[]
            {
                "PAY_2D",
                "PAY_SMART_2D"
            };
            return list.Contains(api_name);
        }

        public static bool isLicenseOwnerTenant()
        {
            var brand_code = Brand.name_code;
            var brand_list = new string[]
            {
                !Constants.BRAND_NAME_CODE_LIST.ContainsKey("SP") ? "" : Constants.BRAND_NAME_CODE_LIST["SP"]
            };


            return brand_list.Contains(brand_code);
        }

        public static bool IsTenant()
        {
            var brand_code = Brand.name_code;
            var brand_list = new string[]
            {
                !Constants.BRAND_NAME_CODE_LIST.ContainsKey("QP_TENANT")
                    ? ""
                    : Constants.BRAND_NAME_CODE_LIST["QP_TENANT"]
            };


            return brand_list.Contains(brand_code);
        }

        public static bool IsTestTransaction()
        {
            // "TEST" means  0.1 , For any other valuue, it  is actual amount
            if (Constants.APPLICATION_STATE == "TEST")
            {
                return true;
            }

            return false;
        }

        public static bool AllowTakePaymentFeature()
        {
            var brand_code = Brand.name_code;

            if (string.IsNullOrEmpty(brand_code)) return false;

            var brand_list = new string[]
            {
                !Constants.BRAND_NAME_CODE_LIST.ContainsKey("FL") ? string.Empty : Constants.BRAND_NAME_CODE_LIST["FL"],
                !Constants.BRAND_NAME_CODE_LIST.ContainsKey("PN") ? string.Empty : Constants.BRAND_NAME_CODE_LIST["PN"],
                !Constants.BRAND_NAME_CODE_LIST.ContainsKey("DP") ? string.Empty : Constants.BRAND_NAME_CODE_LIST["DP"],
                !Constants.BRAND_NAME_CODE_LIST.ContainsKey("EP") ? string.Empty : Constants.BRAND_NAME_CODE_LIST["EP"],
                !Constants.BRAND_NAME_CODE_LIST.ContainsKey("SR") ? string.Empty : Constants.BRAND_NAME_CODE_LIST["SR"],
                !Constants.BRAND_NAME_CODE_LIST.ContainsKey("AP") ? string.Empty : Constants.BRAND_NAME_CODE_LIST["AP"],
                !Constants.BRAND_NAME_CODE_LIST.ContainsKey("MP") ? string.Empty : Constants.BRAND_NAME_CODE_LIST["MP"],
                !Constants.BRAND_NAME_CODE_LIST.ContainsKey("PP") ? string.Empty : Constants.BRAND_NAME_CODE_LIST["PP"],
                !Constants.BRAND_NAME_CODE_LIST.ContainsKey("SD") ? string.Empty : Constants.BRAND_NAME_CODE_LIST["SD"],
                !Constants.BRAND_NAME_CODE_LIST.ContainsKey("PL") ? string.Empty : Constants.BRAND_NAME_CODE_LIST["PL"],
                !Constants.BRAND_NAME_CODE_LIST.ContainsKey("PC") ? string.Empty : Constants.BRAND_NAME_CODE_LIST["PC"],
            };

            return brand_list.Contains(brand_code);
        }

        public static bool AllowIpRestriction()
        {
            var brand_code = Brand.name_code;

            if (string.IsNullOrEmpty(brand_code)) return false;

            var brand_list = new string[]
            {
                !Constants.BRAND_NAME_CODE_LIST.ContainsKey("FP") ? string.Empty : Constants.BRAND_NAME_CODE_LIST["FP"],
                !Constants.BRAND_NAME_CODE_LIST.ContainsKey("SR") ? string.Empty : Constants.BRAND_NAME_CODE_LIST["SR"],
                !Constants.BRAND_NAME_CODE_LIST.ContainsKey("HP") ? string.Empty : Constants.BRAND_NAME_CODE_LIST["HP"],
                !Constants.BRAND_NAME_CODE_LIST.ContainsKey("MOP")
                    ? string.Empty
                    : Constants.BRAND_NAME_CODE_LIST["MOP"],
                !Constants.BRAND_NAME_CODE_LIST.ContainsKey("QP") ? string.Empty : Constants.BRAND_NAME_CODE_LIST["QP"],
                !Constants.BRAND_NAME_CODE_LIST.ContainsKey("QP_TENANT")
                    ? string.Empty
                    : Constants.BRAND_NAME_CODE_LIST["QP_TENANT"]
            };

            return brand_list.Contains(brand_code);
        }

        public static bool IgnoreTokenValidation()
        {
            var brand_code = Brand.name_code;

            if (string.IsNullOrEmpty(brand_code)) return false;

            var brand_list = new string[]
            {
                !Constants.BRAND_NAME_CODE_LIST.ContainsKey("HP") ? string.Empty : Constants.BRAND_NAME_CODE_LIST["HP"]
            };
            return brand_list.Contains(brand_code);
        }

        public static bool IsBrandAllowedCardIssuerNameInGetPosResponse()
        {
            var brand_code = Brand.name_code;

            if (string.IsNullOrEmpty(brand_code)) return false;

            var brand_list = new string[]
            {
                !Constants.BRAND_NAME_CODE_LIST.ContainsKey("PB") ? string.Empty : Constants.BRAND_NAME_CODE_LIST["PB"]
            };

            return brand_list.Contains(brand_code);
        }

        public static bool IsEnableCustomBinDigit()
        {
            bool is_enable_custom_bin_digit = Convert.ToBoolean(Constants.IS_ENABLE_CUSTOM_DIGIT_BIN);

            return is_enable_custom_bin_digit;
        }

        public static int GetCustomBinDigitLength()
        {
            var bin_digit_length = 6;

            if (IsEnableCustomBinDigit())
            {
                bin_digit_length = Constants.CUSTOM_DIGIT_BIN;
            }

            return bin_digit_length;
        }

        public static bool AllowMilesAndSmilesCardList()
        {
            var brand_code = Brand.name_code;

            if (string.IsNullOrEmpty(brand_code)) return false;

            var brand_list = new string[]
            {
                !Constants.BRAND_NAME_CODE_LIST.ContainsKey("PB") ? string.Empty : Constants.BRAND_NAME_CODE_LIST["PB"]
            };

            return brand_list.Contains(brand_code);
        }

        public static bool AllowBankKartCombo()
        {
            var brand_code = Brand.name_code;

            if (string.IsNullOrEmpty(brand_code)) return false;

            var brand_list = new string[]
            {
                !Constants.BRAND_NAME_CODE_LIST.ContainsKey("FP") ? string.Empty : Constants.BRAND_NAME_CODE_LIST["FP"]
            };

            return brand_list.Contains(brand_code);
        }

        public static bool IsAllowCardInfoFromBinRangeQp()
        {
            var brand_code = Brand.name_code;

            if (string.IsNullOrEmpty(brand_code)) return false;

            var brand_list = new string[]
            {
                !Constants.BRAND_NAME_CODE_LIST.ContainsKey("HP") ? string.Empty : Constants.BRAND_NAME_CODE_LIST["HP"],
                !Constants.BRAND_NAME_CODE_LIST.ContainsKey("MOP")
                    ? string.Empty
                    : Constants.BRAND_NAME_CODE_LIST["MOP"],
                !Constants.BRAND_NAME_CODE_LIST.ContainsKey("QP") ? string.Empty : Constants.BRAND_NAME_CODE_LIST["QP"]
            };

            return brand_list.Contains(brand_code);
        }

        public static bool AllowCraftgateApiCall()
        {
            var brand_code = Brand.name_code;

            if (string.IsNullOrEmpty(brand_code)) return false;

            var brand_list = new string[]
            {
                !Constants.BRAND_NAME_CODE_LIST.ContainsKey("SP") ? string.Empty : Constants.BRAND_NAME_CODE_LIST["SP"]
            };

            return brand_list.Contains(brand_code);
        }

        public static bool allowInterTechCurrencyExchangeApi()
        {
            var brand_code = Brand.name_code;
            if (string.IsNullOrEmpty(brand_code)) return false;
            var brand_list = new string[]
            {
                !Constants.BRAND_NAME_CODE_LIST.ContainsKey("FP") ? string.Empty : Constants.BRAND_NAME_CODE_LIST["FP"]
            };

            return brand_list.Contains(brand_code);
        }

        public static bool allowCollectapiCurrecnyExchangeApi()
        {
            var brand_code = Brand.name_code;
            if (string.IsNullOrEmpty(brand_code)) return false;
            var brand_list = new string[]
            {
               
            };

            return brand_list.Contains(brand_code);
        }

        public static bool allowDplMultipleResource()
        {
            var brand_code = Brand.name_code;
            if (string.IsNullOrEmpty(brand_code)) return false;
            var brand_list = new string[]
            {
                !Constants.BRAND_NAME_CODE_LIST.ContainsKey("FP") ? string.Empty : Constants.BRAND_NAME_CODE_LIST["FP"]
            };

            return brand_list.Contains(brand_code);
        }
    }
}