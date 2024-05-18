using ACL.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ACL.Infrastructure.Data
{
    public static class SeedData
    {
        private static readonly string SeedFlagFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "seed.flag");

        private static bool IsSeeded()
        {
            return File.Exists(SeedFlagFilePath);
        }

        private static void MarkSeeded()
        {
            File.Create(SeedFlagFilePath).Close();
        }

        public static void Initialize(IServiceProvider serviceProvider)
        {
            if (!IsSeeded())
            {
                using (var scope = serviceProvider.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    try
                    {
                        var dbContext = services.GetRequiredService<ApplicationDbContext>();

                        try
                        {
                            // Execute raw SQL query to insert data into the AclBranches table
                            dbContext.Database.ExecuteSqlRaw(@"INSERT INTO acl_branches (company_id,name,address,description,status,`sequence`,created_by_id,updated_by_id,created_at,updated_at) VALUES
	 (2,'Default','Dhaka','TEST',1,0,2,2,'2024-05-01 02:59:58.902135','2024-05-01 02:59:58.902019');
INSERT INTO acl_companies (name,cname,cemail,address1,address2,postcode,phone,email,fax,city,state,country,logo,registration_no,timezone,unique_column_name,timezone_value,tax_no,tax_office,sector,average_turnover,no_of_employees,cmmi_level,yearly_revenue,hourly_rate,daily_rate,status,added_by,created_at,updated_at) VALUES
	 ('Default','Admin','ssadmin@softrobotics.com','A','A2','4100','031','ssadmin@softrobotics.com','Fax','C','s','BD','logo','420',254,1,'TimeZone','tax',NULL,NULL,0.0,6,0,0.0,0.0,0.0,1,1,'2015-11-04 01:52:01','2019-03-28 13:29:33');
INSERT INTO acl_company_modules (company_id,module_id,created_at,updated_at) VALUES
	 (1,1001,'2024-05-01 03:00:31','2024-05-01 03:00:31');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(1, 'Afghanistan', 'This is beautiful country', 'AF', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(2, 'Albania', 'This is beautiful country', 'AL', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(3, 'Algeria', 'This is beautiful country', 'DZ', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(4, 'American Samoa', 'This is beautiful country', 'AS', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(5, 'Andorra', 'This is beautiful country', 'AD', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(6, 'Angola', 'This is beautiful country', 'AO', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(7, 'Anguilla', 'This is beautiful country', 'AI', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(8, 'Antarctica', 'This is beautiful country', 'AQ', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(9, 'Antigua and Barbuda', 'This is beautiful country', 'AG', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(10, 'Argentina', 'This is beautiful country', 'AR', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(11, 'Armenia', 'This is beautiful country', 'AM', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(12, 'Aruba', 'This is beautiful country', 'AW', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(13, 'Australia', 'This is beautiful country', 'AU', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(14, 'Austria', 'This is beautiful country', 'AT', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(15, 'Azerbaijan', 'This is beautiful country', 'AZ', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(16, 'Bahamas', 'This is beautiful country', 'BS', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(17, 'Bahrain', 'This is beautiful country', 'BH', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(18, 'Bangladesh', 'This is beautiful country', 'BD', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(19, 'Barbados', 'This is beautiful country', 'BB', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(20, 'Belarus', 'This is beautiful country', 'BY', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(21, 'Belgium', 'This is beautiful country', 'BE', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(22, 'Belize', 'This is beautiful country', 'BZ', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(23, 'Benin', 'This is beautiful country', 'BJ', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(24, 'Bermuda', 'This is beautiful country', 'BM', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(25, 'Bhutan', 'This is beautiful country', 'BT', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(26, 'Bolivia, Plurinational State of', 'This is beautiful country', 'BO', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(27, 'Bonaire, Sint Eustatius and Saba', 'This is beautiful country', 'BQ', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(28, 'Bosnia and Herzegovina', 'This is beautiful country', 'BA', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(29, 'Botswana', 'This is beautiful country', 'BW', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(30, 'Bouvet Island', 'This is beautiful country', 'BV', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(31, 'Brazil', 'This is beautiful country', 'BR', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(32, 'British Indian Ocean Territory', 'This is beautiful country', 'IO', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(33, 'Brunei Darussalam', 'This is beautiful country', 'BN', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(34, 'Bulgaria', 'This is beautiful country', 'BG', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(35, 'Burkina Faso', 'This is beautiful country', 'BF', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(36, 'Burundi', 'This is beautiful country', 'BI', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(37, 'Cambodia', 'This is beautiful country', 'KH', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(38, 'Cameroon', 'This is beautiful country', 'CM', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(39, 'Canada', 'This is beautiful country', 'CA', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(40, 'Cape Verde', 'This is beautiful country', 'CV', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(41, 'Cayman Islands', 'This is beautiful country', 'KY', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(42, 'Central African Republic', 'This is beautiful country', 'CF', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(43, 'Chad', 'This is beautiful country', 'TD', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(44, 'Chile', 'This is beautiful country', 'CL', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(45, 'China', 'This is beautiful country', 'CN', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(46, 'Christmas Island', 'This is beautiful country', 'CX', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(47, 'Cocos (Keeling) Islands', 'This is beautiful country', 'CC', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(48, 'Colombia', 'This is beautiful country', 'CO', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(49, 'Comoros', 'This is beautiful country', 'KM', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(50, 'Congo', 'This is beautiful country', 'CG', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(51, 'Congo, the Democratic Republic of the', 'This is beautiful country', 'CD', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(52, 'Cook Islands', 'This is beautiful country', 'CK', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(53, 'Costa Rica', 'This is beautiful country', 'CR', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(54, 'Croatia', 'This is beautiful country', 'HR', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(55, 'Cuba', 'This is beautiful country', 'CU', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(56, 'CuraÃ§ao', 'This is beautiful country', 'CW', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(57, 'Cyprus', 'This is beautiful country', 'CY', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(58, 'Czech Republic', 'This is beautiful country', 'CZ', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(59, 'CÃ´te d''Ivoire', 'This is beautiful country', 'CI', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(60, 'Denmark', 'This is beautiful country', 'DK', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(61, 'Djibouti', 'This is beautiful country', 'DJ', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(62, 'Dominica', 'This is beautiful country', 'DM', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(63, 'Dominican Republic', 'This is beautiful country', 'DO', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(64, 'Ecuador', 'This is beautiful country', 'EC', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(65, 'Egypt', 'This is beautiful country', 'EG', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(66, 'El Salvador', 'This is beautiful country', 'SV', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(67, 'Equatorial Guinea', 'This is beautiful country', 'GQ', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(68, 'Eritrea', 'This is beautiful country', 'ER', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(69, 'Estonia', 'This is beautiful country', 'EE', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(70, 'Ethiopia', 'This is beautiful country', 'ET', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(71, 'Falkland Islands (Malvinas)', 'This is beautiful country', 'FK', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(72, 'Faroe Islands', 'This is beautiful country', 'FO', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(73, 'Fiji', 'This is beautiful country', 'FJ', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(74, 'Finland', 'This is beautiful country', 'FI', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(75, 'France', 'This is beautiful country', 'FR', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(76, 'French Guiana', 'This is beautiful country', 'GF', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(77, 'French Polynesia', 'This is beautiful country', 'PF', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(78, 'French Southern Territories', 'This is beautiful country', 'TF', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(79, 'Gabon', 'This is beautiful country', 'GA', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(80, 'Gambia', 'This is beautiful country', 'GM', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(81, 'Georgia', 'This is beautiful country', 'GE', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(82, 'Germany', 'This is beautiful country', 'DE', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(83, 'Ghana', 'This is beautiful country', 'GH', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(84, 'Gibraltar', 'This is beautiful country', 'GI', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(85, 'Greece', 'This is beautiful country', 'GR', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(86, 'Greenland', 'This is beautiful country', 'GL', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(87, 'Grenada', 'This is beautiful country', 'GD', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(88, 'Guadeloupe', 'This is beautiful country', 'GP', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(89, 'Guam', 'This is beautiful country', 'GU', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(90, 'Guatemala', 'This is beautiful country', 'GT', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(91, 'Guernsey', 'This is beautiful country', 'GG', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(92, 'Guinea', 'This is beautiful country', 'GN', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(93, 'Guinea-Bissau', 'This is beautiful country', 'GW', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(94, 'Guyana', 'This is beautiful country', 'GY', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(95, 'Haiti', 'This is beautiful country', 'HT', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(96, 'Heard Island and McDonald Islands', 'This is beautiful country', 'HM', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(97, 'Holy See (Vatican City State)', 'This is beautiful country', 'VA', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(98, 'Honduras', 'This is beautiful country', 'HN', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(99, 'Hong Kong', 'This is beautiful country', 'HK', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(100, 'Hungary', 'This is beautiful country', 'HU', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(101, 'Iceland', 'This is beautiful country', 'IS', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(102, 'India', 'This is beautiful country', 'IN', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(103, 'Indonesia', 'This is beautiful country', 'ID', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(104, 'Iran, Islamic Republic of', 'This is beautiful country', 'IR', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(105, 'Iraq', 'This is beautiful country', 'IQ', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(106, 'Ireland', 'This is beautiful country', 'IE', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(107, 'Isle of Man', 'This is beautiful country', 'IM', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(108, 'Israel', 'This is beautiful country', 'IL', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(109, 'Italy', 'This is beautiful country', 'IT', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(110, 'Jamaica', 'This is beautiful country', 'JM', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(111, 'Japan', 'This is beautiful country', 'JP', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(112, 'Jersey', 'This is beautiful country', 'JE', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(113, 'Jordan', 'This is beautiful country', 'JO', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(114, 'Kazakhstan', 'This is beautiful country', 'KZ', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(115, 'Kenya', 'This is beautiful country', 'KE', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(116, 'Kiribati', 'This is beautiful country', 'KI', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(117, 'Korea, Democratic People''s Republic of', 'This is beautiful country', 'KP', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(118, 'Korea, Republic of', 'This is beautiful country', 'KR', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(119, 'Kuwait', 'This is beautiful country', 'KW', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(120, 'Kyrgyzstan', 'This is beautiful country', 'KG', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(121, 'Lao People''s Democratic Republic', 'This is beautiful country', 'LA', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(122, 'Latvia', 'This is beautiful country', 'LV', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(123, 'Lebanon', 'This is beautiful country', 'LB', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(124, 'Lesotho', 'This is beautiful country', 'LS', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(125, 'Liberia', 'This is beautiful country', 'LR', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(126, 'Libya', 'This is beautiful country', 'LY', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(127, 'Liechtenstein', 'This is beautiful country', 'LI', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(128, 'Lithuania', 'This is beautiful country', 'LT', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(129, 'Luxembourg', 'This is beautiful country', 'LU', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(130, 'Macao', 'This is beautiful country', 'MO', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(131, 'Macedonia, the Former Yugoslav Republic of', 'This is beautiful country', 'MK', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(132, 'Madagascar', 'This is beautiful country', 'MG', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(133, 'Malawi', 'This is beautiful country', 'MW', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(134, 'Malaysia', 'This is beautiful country', 'MY', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(135, 'Maldives', 'This is beautiful country', 'MV', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(136, 'Mali', 'This is beautiful country', 'ML', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(137, 'Malta', 'This is beautiful country', 'MT', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(138, 'Marshall Islands', 'This is beautiful country', 'MH', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(139, 'Martinique', 'This is beautiful country', 'MQ', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(140, 'Mauritania', 'This is beautiful country', 'MR', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(141, 'Mauritius', 'This is beautiful country', 'MU', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(142, 'Mayotte', 'This is beautiful country', 'YT', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(143, 'Mexico', 'This is beautiful country', 'MX', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(144, 'Micronesia, Federated States of', 'This is beautiful country', 'FM', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(145, 'Moldova, Republic of', 'This is beautiful country', 'MD', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(146, 'Monaco', 'This is beautiful country', 'MC', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(147, 'Mongolia', 'This is beautiful country', 'MN', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(148, 'Montenegro', 'This is beautiful country', 'ME', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(149, 'Montserrat', 'This is beautiful country', 'MS', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(150, 'Morocco', 'This is beautiful country', 'MA', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(151, 'Mozambique', 'This is beautiful country', 'MZ', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(152, 'Myanmar', 'This is beautiful country', 'MM', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(153, 'Namibia', 'This is beautiful country', 'NA', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(154, 'Nauru', 'This is beautiful country', 'NR', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(155, 'Nepal', 'This is beautiful country', 'NP', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(156, 'Netherlands', 'This is beautiful country', 'NL', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(157, 'New Caledonia', 'This is beautiful country', 'NC', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(158, 'New Zealand', 'This is beautiful country', 'NZ', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(159, 'Nicaragua', 'This is beautiful country', 'NI', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(160, 'Niger', 'This is beautiful country', 'NE', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(161, 'Nigeria', 'This is beautiful country', 'NG', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(162, 'Niue', 'This is beautiful country', 'NU', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(163, 'Norfolk Island', 'This is beautiful country', 'NF', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(164, 'Northern Mariana Islands', 'This is beautiful country', 'MP', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(165, 'Norway', 'This is beautiful country', 'NO', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(166, 'Oman', 'This is beautiful country', 'OM', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(167, 'Pakistan', 'This is beautiful country', 'PK', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(168, 'Palau', 'This is beautiful country', 'PW', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(169, 'Palestine, State of', 'This is beautiful country', 'PS', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(170, 'Panama', 'This is beautiful country', 'PA', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(171, 'Papua New Guinea', 'This is beautiful country', 'PG', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(172, 'Paraguay', 'This is beautiful country', 'PY', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(173, 'Peru', 'This is beautiful country', 'PE', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(174, 'Philippines', 'This is beautiful country', 'PH', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(175, 'Pitcairn', 'This is beautiful country', 'PN', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(176, 'Poland', 'This is beautiful country', 'PL', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(177, 'Portugal', 'This is beautiful country', 'PT', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(178, 'Puerto Rico', 'This is beautiful country', 'PR', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(179, 'Qatar', 'This is beautiful country', 'QA', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(180, 'Romania', 'This is beautiful country', 'RO', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(181, 'Russian Federation', 'This is beautiful country', 'RU', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(182, 'Rwanda', 'This is beautiful country', 'RW', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(183, 'RÃ©union', 'This is beautiful country', 'RE', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(184, 'Saint BarthÃ©lemy', 'This is beautiful country', 'BL', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(185, 'Saint Helena, Ascension and Tristan da Cunha', 'This is beautiful country', 'SH', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(186, 'Saint Kitts and Nevis', 'This is beautiful country', 'KN', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(187, 'Saint Lucia', 'This is beautiful country', 'LC', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(188, 'Saint Martin (French part)', 'This is beautiful country', 'MF', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(189, 'Saint Pierre and Miquelon', 'This is beautiful country', 'PM', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(190, 'Saint Vincent and the Grenadines', 'This is beautiful country', 'VC', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(191, 'Samoa', 'This is beautiful country', 'WS', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(192, 'San Marino', 'This is beautiful country', 'SM', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(193, 'Sao Tome and Principe', 'This is beautiful country', 'ST', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(194, 'Saudi Arabia', 'This is beautiful country', 'SA', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(195, 'Senegal', 'This is beautiful country', 'SN', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(196, 'Serbia', 'This is beautiful country', 'RS', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(197, 'Seychelles', 'This is beautiful country', 'SC', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(198, 'Sierra Leone', 'This is beautiful country', 'SL', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(199, 'Singapore', 'This is beautiful country', 'SG', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(200, 'Sint Maarten (Dutch part)', 'This is beautiful country', 'SX', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(201, 'Slovakia', 'This is beautiful country', 'SK', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(202, 'Slovenia', 'This is beautiful country', 'SI', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(203, 'Solomon Islands', 'This is beautiful country', 'SB', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(204, 'Somalia', 'This is beautiful country', 'SO', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(205, 'South Africa', 'This is beautiful country', 'ZA', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(206, 'South Georgia and the South Sandwich Islands', 'This is beautiful country', 'GS', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(207, 'South Sudan', 'This is beautiful country', 'SS', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(208, 'Spain', 'This is beautiful country', 'ES', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(209, 'Sri Lanka', 'This is beautiful country', 'LK', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(210, 'Sudan', 'This is beautiful country', 'SD', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(211, 'Suriname', 'This is beautiful country', 'SR', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(212, 'Svalbard and Jan Mayen', 'This is beautiful country', 'SJ', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(213, 'Swaziland', 'This is beautiful country', 'SZ', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(214, 'Sweden', 'This is beautiful country', 'SE', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(215, 'Switzerland', 'This is beautiful country', 'CH', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(216, 'Syrian Arab Republic', 'This is beautiful country', 'SY', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(217, 'Taiwan, Province of China', 'This is beautiful country', 'TW', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(218, 'Tajikistan', 'This is beautiful country', 'TJ', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(219, 'Tanzania, United Republic of', 'This is beautiful country', 'TZ', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(220, 'Thailand', 'This is beautiful country', 'TH', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(221, 'Timor-Leste', 'This is beautiful country', 'TL', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(222, 'Togo', 'This is beautiful country', 'TG', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(223, 'Tokelau', 'This is beautiful country', 'TK', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(224, 'Tonga', 'This is beautiful country', 'TO', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(225, 'Trinidad and Tobago', 'This is beautiful country', 'TT', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(226, 'Tunisia', 'This is beautiful country', 'TN', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(227, 'Turkey', 'This is beautiful country', 'TR', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(228, 'Turkmenistan', 'This is beautiful country', 'TM', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(229, 'Turks and Caicos Islands', 'This is beautiful country', 'TC', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(230, 'Tuvalu', 'This is beautiful country', 'TV', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(231, 'Uganda', 'This is beautiful country', 'UG', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(232, 'Ukraine', 'This is beautiful country', 'UA', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(233, 'United Arab Emirates', 'This is beautiful country', 'AE', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(234, 'United Kingdom', 'This is beautiful country', 'GB', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(235, 'United States', 'This is beautiful country', 'US', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(236, 'United States Minor Outlying Islands', 'This is beautiful country', 'UM', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(237, 'Uruguay', 'This is beautiful country', 'UY', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(238, 'Uzbekistan', 'This is beautiful country', 'UZ', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(239, 'Vanuatu', 'This is beautiful country', 'VU', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(240, 'Venezuela, Bolivarian Republic of', 'This is beautiful country', 'VE', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(241, 'Viet Nam', 'This is beautiful country', 'VN', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(242, 'Virgin Islands, British', 'This is beautiful country', 'VG', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(243, 'Virgin Islands, U.S.', 'This is beautiful country', 'VI', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(244, 'Wallis and Futuna', 'This is beautiful country', 'WF', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(245, 'Western Sahara', 'This is beautiful country', 'EH', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(246, 'Yemen', 'This is beautiful country', 'YE', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(247, 'Zambia', 'This is beautiful country', 'ZM', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(248, 'Zimbabwe', 'This is beautiful country', 'ZW', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_countries (id, name, description, code, status, `sequence`, created_by_id, updated_by_id, created_at, updated_at) VALUES(249, 'Ã…land Islands', 'This is beautiful country', 'AX', 1, 0, 2, 2, '2015-11-04 01:52:01', '2019-03-28 13:29:33');
INSERT INTO acl_modules (name,icon,`sequence`,display_name,created_at,updated_at) VALUES
	 ('Company','<i class=""fa fa-list-ul""></i>',6,'Company','2015-12-09 12:10:46','2019-03-20 21:52:50'),
	 ('Master Data','<i class=""fa fa-list-ul""></i>',2,'Master Data','2015-12-09 12:10:46','2019-03-26 22:38:37'),
	 ('Access Control','<img src=""adminca/assets/img/icons/access-control.svg"" />',1099,'Access Control','2015-12-09 12:10:47','2016-08-06 16:24:34');
INSERT INTO acl_page_routes (page_id,route_name,route_url,created_at,updated_at) VALUES
	 (3001,'acl.company.list','companies',NULL,NULL),
	 (3002,'acl.company.add','companies/add',NULL,NULL),
	 (3003,'acl.company.edit','companies/edit/{id}',NULL,NULL),
	 (3004,'acl.company.destroy','companies/delete/{id}',NULL,NULL),
	 (3005,'acl.company.show','companies/view/{id}',NULL,NULL),
	 (3015,'acl.module.list','modules',NULL,NULL),
	 (3016,'acl.module.add','modules/add',NULL,NULL),
	 (3017,'acl.module.edit','modules/edit/{id}',NULL,NULL),
	 (3018,'acl.module.destroy','modules/delete/{id}',NULL,NULL),
	 (3019,'acl.module.view','modules/view/{id}',NULL,NULL);
INSERT INTO acl_page_routes (page_id,route_name,route_url,created_at,updated_at) VALUES
	 (3080,'acl.company_module.list','company/modules',NULL,NULL),
	 (3081,'acl.company_module.add','company/modules/add',NULL,NULL),
	 (3082,'acl.company_module.edit','company/modules/edit/{id}',NULL,NULL),
	 (3083,'acl.company_module.destroy','company/modules/delete/{id}',NULL,NULL),
	 (3084,'acl.company_module.view','company/modules/view/{id}',NULL,NULL),
	 (3025,'acl.submodule.list','submodules',NULL,NULL),
	 (3026,'acl.submodule.add','submodules/add',NULL,NULL),
	 (3027,'acl.submodule.edit','submodules/edit/{id}',NULL,NULL),
	 (3028,'acl.submodule.destroy','submodules/delete/{id}',NULL,NULL),
	 (3029,'acl.submodule.view','submodules/view/{id}',NULL,NULL);
INSERT INTO acl_page_routes (page_id,route_name,route_url,created_at,updated_at) VALUES
	 (3035,'acl.page.list','pages',NULL,NULL),
	 (3036,'acl.page.add','pages/add',NULL,NULL),
	 (3037,'acl.page.edit','pages/edit/{id}',NULL,NULL),
	 (3038,'acl.page.destroy','pages/delete/{id}',NULL,NULL),
	 (3039,'acl.page.view','pages/view/{id}',NULL,NULL),
	 (3045,'acl.user.list','users',NULL,NULL),
	 (3046,'acl.user.add','users/add',NULL,NULL),
	 (3047,'acl.user.edit','users/edit/{id}',NULL,NULL),
	 (3048,'acl.user.destroy','users/delete/{id}',NULL,NULL),
	 (3049,'acl.user.view','users/view/{id}',NULL,NULL);
INSERT INTO acl_page_routes (page_id,route_name,route_url,created_at,updated_at) VALUES
	 (3055,'acl.role.list','roles',NULL,NULL),
	 (3056,'acl.role.add','roles/add',NULL,NULL),
	 (3057,'acl.role.edit','roles/edit/{id}',NULL,NULL),
	 (3058,'acl.role.destroy','roles/delete/{id}',NULL,NULL),
	 (3059,'acl.role.view','roles/view/{id}',NULL,NULL),
	 (3065,'acl.usergroups.list','usergroups',NULL,NULL),
	 (3066,'acl.usergroups.add','usergroups/add',NULL,NULL),
	 (3067,'acl.usergroups.edit','usergroups/edit/{id}',NULL,NULL),
	 (3068,'acl.usergroups.destroy','usergroups/delete/{id}',NULL,NULL),
	 (3069,'acl.usergroups.view','usergroups/view/{id}',NULL,NULL);
INSERT INTO acl_page_routes (page_id,route_name,route_url,created_at,updated_at) VALUES
	 (3075,'acl.usergroups.role.association','usergroups/roles/{user_group_id}',NULL,NULL),
	 (3076,'acl.usergroups.role.association.update','usergroups/roles/update',NULL,NULL),
	 (3078,'acl.role&page.association','permissions/associations/{role_id}',NULL,NULL),
	 (3079,'acl.role&page.association.update','permissions/associations/update',NULL,NULL),
	 (3036,'acl.page.route.add','pages/routes/add',NULL,NULL),
	 (3037,'acl.page.route.edit','pages/routes/edit/{id}',NULL,NULL),
	 (3038,'acl.page.route.destroy','pages/routes/delete/{id}',NULL,NULL);
INSERT INTO acl_pages (module_id,sub_module_id,name,method_name,method_type,available_to_company,created_at,updated_at) VALUES
	 (1001,2001,'Company List','index',0,0,'2015-12-09 12:10:51','2015-12-09 12:10:51'),
	 (1001,2001,'Add New Company','create',0,0,'2015-12-09 12:10:52','2015-12-09 12:10:52'),
	 (1001,2001,'Modify Company','edit',2,0,'2015-12-09 12:10:52','2019-03-27 15:03:28'),
	 (1001,2001,'Delete Company','destroy',2,0,'2015-12-09 12:10:52','2019-03-26 22:42:31'),
	 (1001,2001,'View Company','show',0,0,'2015-12-09 12:10:52','2015-12-09 12:10:52'),
	 (1002,2020,'Module List','index',0,0,'2015-12-09 12:10:53','2015-12-09 12:10:53'),
	 (1002,2020,'Add New Module','create',0,0,'2015-12-09 12:10:53','2015-12-09 12:10:53'),
	 (1002,2020,'Modify Module','edit',0,0,'2015-12-09 12:10:53','2015-12-09 12:10:53'),
	 (1002,2020,'Delete Module','destroy',0,0,'2015-12-09 12:10:54','2015-12-09 12:10:54'),
	 (1002,2020,'View Module','view',0,0,'2015-12-09 12:10:54','2015-12-09 12:10:54');
INSERT INTO acl_pages (module_id,sub_module_id,name,method_name,method_type,available_to_company,created_at,updated_at) VALUES
	 (1002,2021,'Submodule List','index',0,0,'2015-12-09 12:10:54','2015-12-09 12:10:54'),
	 (1002,2021,'Add New Submodule','create',0,0,'2015-12-09 12:10:54','2015-12-09 12:10:54'),
	 (1002,2021,'Modify Submodule','edit',0,0,'2015-12-09 12:10:54','2015-12-09 12:10:54'),
	 (1002,2021,'Delete Submodule','destroy',0,0,'2015-12-09 12:10:55','2015-12-09 12:10:55'),
	 (1002,2021,'View Submodule','view',0,0,'2015-12-09 12:10:55','2015-12-09 12:10:55'),
	 (1002,2022,'Page List','index',0,0,'2015-12-09 12:10:55','2015-12-09 12:10:55'),
	 (1002,2022,'Add New Page','create',0,0,'2015-12-09 12:10:55','2016-01-21 10:44:25'),
	 (1002,2022,'Modify Page','edit',0,0,'2015-12-09 12:10:56','2015-12-09 12:10:56'),
	 (1002,2022,'Delete Page','destroy',0,0,'2015-12-09 12:10:56','2015-12-09 12:10:56'),
	 (1002,2022,'View Page','view',0,0,'2015-12-09 12:10:56','2015-12-09 12:10:56');
INSERT INTO acl_pages (module_id,sub_module_id,name,method_name,method_type,available_to_company,created_at,updated_at) VALUES
	 (1003,2050,'User List','index',0,1,'2015-12-09 12:10:56','2015-12-09 12:10:56'),
	 (1003,2050,'User Add','create',0,1,'2015-12-09 12:10:57','2015-12-09 12:10:57'),
	 (1003,2050,'User Edit','edit',0,1,'2015-12-09 12:10:57','2015-12-09 12:10:57'),
	 (1003,2050,'User Delete','destroy',0,1,'2015-12-09 12:10:57','2015-12-09 12:10:57'),
	 (1003,2050,'User View','view',0,0,'2015-11-22 23:13:47','2015-11-22 23:13:47'),
	 (1003,2051,'Role List','index',0,1,'2015-12-09 12:12:02','2015-12-09 12:12:02'),
	 (1003,2051,'Role Add','create',0,1,'2015-12-09 12:12:02','2015-12-09 12:12:02'),
	 (1003,2051,'Role Edit','edit',0,1,'2015-12-09 12:12:03','2015-12-09 12:12:03'),
	 (1003,2051,'Role Delete','destroy',0,1,'2015-12-09 12:12:03','2015-12-09 12:12:03'),
	 (1003,2051,'Role View','view',0,1,'2015-12-09 12:12:03','2015-12-09 12:12:03');
INSERT INTO acl_pages (module_id,sub_module_id,name,method_name,method_type,available_to_company,created_at,updated_at) VALUES
	 (1003,2052,'UserGroup List','index',0,1,'2015-12-09 12:12:03','2015-12-09 12:12:03'),
	 (1003,2052,'UserGroup Add','create',0,1,'2015-12-09 12:12:04','2015-12-09 12:12:04'),
	 (1003,2052,'UserGroup Edit','edit',0,1,'2015-12-09 12:12:04','2015-12-09 12:12:04'),
	 (1003,2052,'UserGroup Delete','destroy',0,1,'2015-12-09 12:12:04','2015-12-09 12:12:04'),
	 (1003,2052,'UserGroup View','view',0,1,'2015-12-09 12:12:04','2015-12-09 12:12:04'),
	 (1003,2053,'Usergroup Role Association','index',0,1,'2015-12-09 12:12:05','2015-12-09 12:12:05'),
	 (1003,2053,'Usergroup & Role Association Update','edit',0,1,'2021-12-09 15:10:51','2021-12-09 15:10:51'),
	 (1003,2054,'Role & Page Association','index',0,1,'2015-12-09 12:12:05','2015-12-09 12:12:05'),
	 (1003,2054,'Role & Page Association Update','edit',0,1,'2021-12-09 15:10:51','2021-12-09 15:10:51'),
	 (1003,2055,'Company Module List','index',0,0,'2015-12-09 12:10:51','2015-12-09 12:10:51');
INSERT INTO acl_pages (module_id,sub_module_id,name,method_name,method_type,available_to_company,created_at,updated_at) VALUES
	 (1003,2055,'Add New Company Module','create',0,0,'2015-12-09 12:10:52','2015-12-09 12:10:52'),
	 (1003,2055,'Modify Company Module','edit',2,0,'2015-12-09 12:10:52','2019-03-27 15:03:28'),
	 (1003,2055,'Delete Company Module','destroy',2,0,'2015-12-09 12:10:52','2019-03-26 22:42:31'),
	 (1003,2055,'View Company Module','show',0,0,'2015-12-09 12:10:52','2015-12-09 12:10:52');
INSERT INTO acl_role_pages (role_id,page_id,created_at,updated_at) VALUES
	 (1,3001,NULL,NULL),
	 (1,3002,NULL,NULL),
	 (1,3003,NULL,NULL),
	 (1,3004,NULL,NULL),
	 (1,3005,NULL,NULL),
	 (1,3015,NULL,NULL),
	 (1,3016,NULL,NULL),
	 (1,3017,NULL,NULL),
	 (1,3018,NULL,NULL),
	 (1,3019,NULL,NULL);
INSERT INTO acl_role_pages (role_id,page_id,created_at,updated_at) VALUES
	 (1,3025,NULL,NULL),
	 (1,3026,NULL,NULL),
	 (1,3027,NULL,NULL),
	 (1,3028,NULL,NULL),
	 (1,3029,NULL,NULL),
	 (1,3035,NULL,NULL),
	 (1,3036,NULL,NULL),
	 (1,3037,NULL,NULL),
	 (1,3038,NULL,NULL),
	 (1,3039,NULL,NULL);
INSERT INTO acl_role_pages (role_id,page_id,created_at,updated_at) VALUES
	 (1,3080,NULL,NULL),
	 (1,3081,NULL,NULL),
	 (1,3082,NULL,NULL),
	 (1,3083,NULL,NULL),
	 (1,3084,NULL,NULL);
INSERT INTO acl_roles (title,name,status,company_id,created_by_id,updated_by_id,created_at,updated_at) VALUES
	 ('super-super-admin','',1,1,NULL,NULL,'2019-03-21 20:38:30','2015-11-09 07:17:00');
INSERT INTO acl_states (company_id,country_id,name,description,status,`sequence`,created_by_id,updated_by_id,created_at,updated_at) VALUES
	 (1,1,'Florida','Florida is state of USA',1,100,2,2,'2024-05-01 03:02:07.804194','2024-05-01 03:02:07.804427');
INSERT INTO acl_sub_modules (module_id,name,controller_name,icon,`sequence`,default_method,display_name,created_at,updated_at) VALUES
	 (1001,'Company Management','CompanyController','<i class=""fa fa-angle-double-right""></i>',100,'index','Company Management','2015-12-09 12:10:47','2015-12-09 12:10:47'),
	 (1002,'Module Management','ModuleController','<i class=""fa fa-angle-double-right""></i>',100,'index','Module Management','2015-12-09 12:10:48','2015-12-09 12:10:48'),
	 (1002,'Sub Module Management','SubModuleController','<i class=""fa fa-angle-double-right""></i>',101,'index','Sub Module Management','2015-12-09 12:10:48','2015-12-09 12:10:48'),
	 (1002,'Page Management','PageController','<i class=""fa fa-angle-double-right""></i>',102,'index','Page Management','2015-12-09 12:10:48','2015-12-09 12:10:48'),
	 (1003,'User Management','UserController','<i class=""fa fa-angle-double-right""></i>',18,'index','User Management','2015-12-09 12:10:49','2015-12-09 12:10:49'),
	 (1003,'Role Management','RoleController','<i class=""fa fa-angle-double-right""></i>',101,'index','Role Management','2015-12-09 12:10:49','2015-12-23 14:35:45'),
	 (1003,'User Group Management','UsergroupController','<i class=""fa fa-angle-double-right""></i>',102,'index','User Group Management','2015-12-09 12:10:49','2015-12-09 12:10:49'),
	 (1003,'Usergroup & Role Association','UsergroupRoleController','<i class=""fa fa-angle-double-right""></i>',103,'index','Usergroup & Role Association','2015-12-09 12:10:49','2015-12-09 12:10:49'),
	 (1003,'Role & Page Association','RolePageController','<i class=""fa fa-angle-double-right""></i>',104,'index','Role & Page Association','2015-12-09 12:10:50','2015-12-09 12:10:50'),
	 (1003,'Company Module Management','CompanyModuleController','<i class=""fa fa-angle-double-right""></i>',105,'index','Company Module Management','2015-12-09 12:10:48','2015-12-09 12:10:48');
INSERT INTO acl_user_usergroups (usergroup_id,user_id,company_id,created_at,updated_at) VALUES
	 (1,1,1,'2024-01-24 07:23:21','2024-01-24 07:23:23');
INSERT INTO acl_usergroup_roles (usergroup_id,role_id,company_id,created_at,updated_at) VALUES
	 (1,1,1,NULL,NULL);
INSERT INTO acl_usergroups (group_name,category,dashboard_url,status,company_id,created_at,updated_at) VALUES
	 ('super-super-admin-group',0,NULL,1,1,'2019-03-22 08:38:12','2023-11-01 19:17:00');
INSERT INTO acl_users (id, first_name, last_name, email, avatar, password, dob, gender, address, city, country, phone, is_admin_verified, user_type, remember_token, created_at, updated_at, activated_at, `language`, username, img_path, status, company_id, permission_version, otp_channel, login_at, created_by_id, auth_identifier, claims, refresh_token, salt) VALUES(1, 'admin1', 'admin1', 'ssadmin@sipay.com.tr', 'users/admin/c41353d1c1fcbdbd39f96ea46a3f769136952e79.png', 'QCy4DY93n7XSPqOJAjrq9hmwoIuaq9zqbDUBXmXPs+DgWlbGHBxWVQTlQVdmmUYUk0D21muGuNGQr32ro0zFdA==', '1994-02-22 00:00:00', 1, 'Dhaka', '19', 0, '+8801788343704', 1, 0, NULL, '2018-07-10 16:21:24', '2021-08-25 05:46:27', NULL, 'en-US', 'rajibecbb', 'storage/users/1/2019-04-18-07-49-28-ba4fe9be59df7b82f8243d2126070d76f5305b3e.png', 1, 1, 1, 0, NULL, 1, NULL, '[{""Type"":""scope"",""Value"":""CanReadWeather""}]', '{""Value"":null,""Active"":false,""ExpirationDate"":""0001-01-01T00:00:00""}', 'pNr7R0FzsicCDrMlIwXYVI6zM4rZByVgNCkWRwM4y57Sw+cdKUbTrRZLbV8nccwNlN+DokHXlkxKGvw+7ISPPw==');
INSERT INTO acl_usertype_submodules (user_type_id,sub_module_id,created_at,updated_at) VALUES
	 (0,2001,NULL,NULL),
	 (0,2020,NULL,NULL),
	 (0,2021,NULL,NULL),
	 (0,2022,NULL,NULL),
	 (1,2050,NULL,NULL),
	 (1,2051,NULL,NULL),
	 (1,2052,NULL,NULL),
	 (1,2053,NULL,NULL),
	 (1,2054,NULL,NULL);
");
                            // Save changes to persist the data
                            dbContext.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            // Log any exceptions
                            var logger = services.GetRequiredService<ILogger<dynamic>>();
                            logger.LogError(ex, "An error occurred while seeding the database.");
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log any exceptions
                        var logger = services.GetRequiredService<ILogger<dynamic>>();
                        logger.LogError(ex, "An error occurred while seeding the database.");

                    }

                }
            }
        }
    }

}
