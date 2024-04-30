using ACL.Database;
using ACL.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace ACL.Data
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
INSERT INTO acl_countries (company_id,name,description,code,status,`sequence`,created_by_id,updated_by_id,created_at,updated_at) VALUES
	 (0,'Bangladesh','This is beautiful country','bn',1,0,2,2,'2024-05-01 03:01:56.388105','2024-05-01 03:01:56.388288');
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
INSERT INTO acl_users (first_name,last_name,email,avatar,password,dob,gender,address,city,country,phone,is_admin_verified,user_type,remember_token,created_at,updated_at,activated_at,`language`,username,img_path,status,company_id,permission_version,otp_channel,login_at,created_by_id,auth_identifier) VALUES
	 ('admin1','admin1','ssadmin@sipay.com.tr','users/admin/c41353d1c1fcbdbd39f96ea46a3f769136952e79.png','Nop@ss1234','1994-02-22 00:00:00',1,'Dhaka','19',0,'+8801788343704',1,0,'','2018-07-10 16:21:24','2021-08-25 05:46:27',NULL,'en','rajibecbb','storage/users/1/2019-04-18-07-49-28-ba4fe9be59df7b82f8243d2126070d76f5305b3e.png',1,1,1,0,NULL,1,NULL);
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
