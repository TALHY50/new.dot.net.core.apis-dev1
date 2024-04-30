INSERT INTO acl.acl_companies (name,cname,cemail,address1,address2,postcode,phone,email,fax,city,state,country,logo,registration_no,timezone,unique_column_name,timezone_value,tax_no,tax_office,sector,average_turnover,no_of_employees,cmmi_level,yearly_revenue,hourly_rate,daily_rate,status,added_by,created_at,updated_at) VALUES
	 ('Default','Admin','ssadmin@softrobotics.com','A','A2','4100','031','ssadmin@softrobotics.com','','C','s','BD','','',254,1,'','','','',0.0,6,0,0.0,0.0,0.0,1,1,'2015-11-04 01:52:01','2019-03-28 13:29:33'),
	 ('Porosh','Testing Company','porosh@gmail.com','asdfag sdfasdf','asdfg asdfsadf','1230','01672896992','siddique@gmail.com','asdfasdf','Dahka','Dhaka','Bangladesh','asdfasdfasdf.png','asdfasdf',-11,1,'asdfasdf','asdfasdf',NULL,NULL,0.0,0,0,0.0,0.0,0.0,1,1,'2024-03-07 13:25:44','2024-03-07 13:25:44'),
	 ('Mahmud','Test Company','mahmud@gmail.com','asdfa sdfasdf','asdf asdfsadf','1229','01521497833','korim@gmail.com','asdfasdf','Dahka','Dhaka','Bangladesh','asdfasdfasdf.png','asdfasdf',-11,1,'asdfasdf','asdfasdf',NULL,NULL,0.0,0,0,0.0,0.0,0.0,1,1,'2024-03-07 13:25:44','2024-03-07 13:25:44');

	 INSERT INTO acl.acl_company_modules (company_id,module_id,created_at,updated_at) VALUES
	 (2,1002,'2024-03-12 04:27:20','2024-03-12 04:27:20');

	 INSERT INTO acl.acl_modules (id,name,icon,sequence,display_name,created_at,updated_at) VALUES
	 (1001,'Company','<i class="fa fa-list-ul"></i>',6,'Company','2015-12-09 12:10:46','2019-03-20 21:52:50'),
	 (1002,'Master Data','<i class="fa fa-list-ul"></i>',2,'Master Data','2015-12-09 12:10:46','2019-03-26 22:38:37'),
	 (1003,'Access Control','<img src="adminca/assets/img/icons/access-control.svg" />',1099,'Access Control','2015-12-09 12:10:47','2016-08-06 16:24:34');

	 INSERT INTO acl.acl_page_routes (page_id,route_name,route_url,created_at,updated_at) VALUES
	 (3001,'acl.company.list','companies',NULL,NULL),
	 (3002,'acl.company.add','companies/add',NULL,NULL),
	 (3003,'acl.company.edit','companies/edit/{id}',NULL,NULL),
	 (3004,'acl.company.destroy','companies/delete/{id}',NULL,NULL),
	 (3005,'acl.company.show','companies/view/{id}',NULL,NULL),
	 (3015,'acl.module.list','modules',NULL,NULL),
	 (3016,'acl.module.add','modules/add',NULL,NULL),
	 (3017,'acl.module.edit','modules/edit/{id}',NULL,NULL),
	 (3018,'acl.module.destroy','modules/delete/{id}',NULL,NULL),
	 (3019,'acl.module.view','modules/view/{id}',NULL,NULL),
	 (3080,'acl.company_module.list','company/modules',NULL,NULL),
	 (3081,'acl.company_module.add','company/modules/add',NULL,NULL),
	 (3082,'acl.company_module.edit','company/modules/edit/{id}',NULL,NULL),
	 (3083,'acl.company_module.destroy','company/modules/delete/{id}',NULL,NULL),
	 (3084,'acl.company_module.view','company/modules/view/{id}',NULL,NULL),
	 (3025,'acl.submodule.list','submodules',NULL,NULL),
	 (3026,'acl.submodule.add','submodules/add',NULL,NULL),
	 (3027,'acl.submodule.edit','submodules/edit/{id}',NULL,NULL),
	 (3028,'acl.submodule.destroy','submodules/delete/{id}',NULL,NULL),
	 (3029,'acl.submodule.view','submodules/view/{id}',NULL,NULL),
	 (3035,'acl.page.list','pages',NULL,NULL),
	 (3036,'acl.page.add','pages/add',NULL,NULL),
	 (3037,'acl.page.edit','pages/edit/{id}',NULL,NULL),
	 (3038,'acl.page.destroy','pages/delete/{id}',NULL,NULL),
	 (3039,'acl.page.view','pages/view/{id}',NULL,NULL),
	 (3045,'acl.user.list','users',NULL,NULL),
	 (3046,'acl.user.add','users/add',NULL,NULL),
	 (3047,'acl.user.edit','users/edit/{id}',NULL,NULL),
	 (3048,'acl.user.destroy','users/delete/{id}',NULL,NULL),
	 (3049,'acl.user.view','users/view/{id}',NULL,NULL),
	 (3055,'acl.role.list','roles',NULL,NULL),
	 (3056,'acl.role.add','roles/add',NULL,NULL),
	 (3057,'acl.role.edit','roles/edit/{id}',NULL,NULL),
	 (3058,'acl.role.destroy','roles/delete/{id}',NULL,NULL),
	 (3059,'acl.role.view','roles/view/{id}',NULL,NULL),
	 (3065,'acl.usergroups.list','usergroups',NULL,NULL),
	 (3066,'acl.usergroups.add','usergroups/add',NULL,NULL),
	 (3067,'acl.usergroups.edit','usergroups/edit/{id}',NULL,NULL),
	 (3068,'acl.usergroups.destroy','usergroups/delete/{id}',NULL,NULL),
	 (3069,'acl.usergroups.view','usergroups/view/{id}',NULL,NULL),
	 (3075,'acl.usergroups.role.association','usergroups/roles/{user_group_id}',NULL,NULL),
	 (3076,'acl.usergroups.role.association.update','usergroups/roles/update',NULL,NULL),
	 (3078,'acl.role&page.association','permissions/associations/{role_id}',NULL,NULL),
	 (3079,'acl.role&page.association.update','permissions/associations/update',NULL,NULL),
	 (3036,'acl.page.route.add','pages/routes/add',NULL,NULL),
	 (3037,'acl.page.route.edit','pages/routes/edit/{id}',NULL,NULL),
	 (3038,'acl.page.route.destroy','pages/routes/delete/{id}',NULL,NULL);


INSERT INTO acl.acl_pages (id,module_id,sub_module_id,name,method_name,method_type,available_to_company,created_at,updated_at) VALUES
	 (3001,1001,2001,'Company List','index',0,0,'2015-12-09 12:10:51','2015-12-09 12:10:51'),
	 (3002,1001,2001,'Add New Company','create',0,0,'2015-12-09 12:10:52','2015-12-09 12:10:52'),
	 (3003,1001,2001,'Modify Company','edit',2,0,'2015-12-09 12:10:52','2019-03-27 15:03:28'),
	 (3004,1001,2001,'Delete Company','destroy',2,0,'2015-12-09 12:10:52','2019-03-26 22:42:31'),
	 (3005,1001,2001,'View Company','show',0,0,'2015-12-09 12:10:52','2015-12-09 12:10:52'),
	 (3015,1002,2020,'Module List','index',0,0,'2015-12-09 12:10:53','2015-12-09 12:10:53'),
	 (3016,1002,2020,'Add New Module','create',0,0,'2015-12-09 12:10:53','2015-12-09 12:10:53'),
	 (3017,1002,2020,'Modify Module','edit',0,0,'2015-12-09 12:10:53','2015-12-09 12:10:53'),
	 (3018,1002,2020,'Delete Module','destroy',0,0,'2015-12-09 12:10:54','2015-12-09 12:10:54'),
	 (3019,1002,2020,'View Module','view',0,0,'2015-12-09 12:10:54','2015-12-09 12:10:54'),
	 (3025,1002,2021,'Submodule List','index',0,0,'2015-12-09 12:10:54','2015-12-09 12:10:54'),
	 (3026,1002,2021,'Add New Submodule','create',0,0,'2015-12-09 12:10:54','2015-12-09 12:10:54'),
	 (3027,1002,2021,'Modify Submodule','edit',0,0,'2015-12-09 12:10:54','2015-12-09 12:10:54'),
	 (3028,1002,2021,'Delete Submodule','destroy',0,0,'2015-12-09 12:10:55','2015-12-09 12:10:55'),
	 (3029,1002,2021,'View Submodule','view',0,0,'2015-12-09 12:10:55','2015-12-09 12:10:55'),
	 (3035,1002,2022,'Page List','index',0,0,'2015-12-09 12:10:55','2015-12-09 12:10:55'),
	 (3036,1002,2022,'Add New Page','create',0,0,'2015-12-09 12:10:55','2016-01-21 10:44:25'),
	 (3037,1002,2022,'Modify Page','edit',0,0,'2015-12-09 12:10:56','2015-12-09 12:10:56'),
	 (3038,1002,2022,'Delete Page','destroy',0,0,'2015-12-09 12:10:56','2015-12-09 12:10:56'),
	 (3039,1002,2022,'View Page','view',0,0,'2015-12-09 12:10:56','2015-12-09 12:10:56'),
	 (3045,1003,2050,'User List','index',0,1,'2015-12-09 12:10:56','2015-12-09 12:10:56'),
	 (3046,1003,2050,'User Add','create',0,1,'2015-12-09 12:10:57','2015-12-09 12:10:57'),
	 (3047,1003,2050,'User Edit','edit',0,1,'2015-12-09 12:10:57','2015-12-09 12:10:57'),
	 (3048,1003,2050,'User Delete','destroy',0,1,'2015-12-09 12:10:57','2015-12-09 12:10:57'),
	 (3049,1003,2050,'User View','view',0,0,'2015-11-22 23:13:47','2015-11-22 23:13:47'),
	 (3055,1003,2051,'Role List','index',0,1,'2015-12-09 12:12:02','2015-12-09 12:12:02'),
	 (3056,1003,2051,'Role Add','create',0,1,'2015-12-09 12:12:02','2015-12-09 12:12:02'),
	 (3057,1003,2051,'Role Edit','edit',0,1,'2015-12-09 12:12:03','2015-12-09 12:12:03'),
	 (3058,1003,2051,'Role Delete','destroy',0,1,'2015-12-09 12:12:03','2015-12-09 12:12:03'),
	 (3059,1003,2051,'Role View','view',0,1,'2015-12-09 12:12:03','2015-12-09 12:12:03'),
	 (3065,1003,2052,'UserGroup List','index',0,1,'2015-12-09 12:12:03','2015-12-09 12:12:03'),
	 (3066,1003,2052,'UserGroup Add','create',0,1,'2015-12-09 12:12:04','2015-12-09 12:12:04'),
	 (3067,1003,2052,'UserGroup Edit','edit',0,1,'2015-12-09 12:12:04','2015-12-09 12:12:04'),
	 (3068,1003,2052,'UserGroup Delete','destroy',0,1,'2015-12-09 12:12:04','2015-12-09 12:12:04'),
	 (3069,1003,2052,'UserGroup View','view',0,1,'2015-12-09 12:12:04','2015-12-09 12:12:04'),
	 (3075,1003,2053,'Usergroup Role Association','index',0,1,'2015-12-09 12:12:05','2015-12-09 12:12:05'),
	 (3076,1003,2053,'Usergroup & Role Association Update','edit',0,1,'2021-12-09 15:10:51','2021-12-09 15:10:51'),
	 (3078,1003,2054,'Role & Page Association','index',0,1,'2015-12-09 12:12:05','2015-12-09 12:12:05'),
	 (3079,1003,2054,'Role & Page Association Update','edit',0,1,'2021-12-09 15:10:51','2021-12-09 15:10:51'),
	 (3080,1003,2055,'Company Module List','index',0,0,'2015-12-09 12:10:51','2015-12-09 12:10:51'),
	 (3081,1003,2055,'Add New Company Module','create',0,0,'2015-12-09 12:10:52','2015-12-09 12:10:52'),
	 (3082,1003,2055,'Modify Company Module','edit',2,0,'2015-12-09 12:10:52','2019-03-27 15:03:28'),
	 (3083,1003,2055,'Delete Company Module','destroy',2,0,'2015-12-09 12:10:52','2019-03-26 22:42:31'),
	 (3084,1003,2055,'View Company Module','show',0,0,'2015-12-09 12:10:52','2015-12-09 12:10:52');


	 INSERT INTO acl.acl_role_pages (role_id,page_id,created_at,updated_at) VALUES
	 (1,3001,NULL,NULL),
	 (1,3002,NULL,NULL),
	 (1,3003,NULL,NULL),
	 (1,3004,NULL,NULL),
	 (1,3005,NULL,NULL),
	 (1,3015,NULL,NULL),
	 (1,3016,NULL,NULL),
	 (1,3017,NULL,NULL),
	 (1,3018,NULL,NULL),
	 (1,3019,NULL,NULL),
	 (1,3025,NULL,NULL),
	 (1,3026,NULL,NULL),
	 (1,3027,NULL,NULL),
	 (1,3028,NULL,NULL),
	 (1,3029,NULL,NULL),
	 (1,3035,NULL,NULL),
	 (1,3036,NULL,NULL),
	 (1,3037,NULL,NULL),
	 (1,3038,NULL,NULL),
	 (1,3039,NULL,NULL),
	 (1,3080,NULL,NULL),
	 (1,3081,NULL,NULL),
	 (1,3082,NULL,NULL),
	 (1,3083,NULL,NULL),
	 (1,3084,NULL,NULL),
	 (2,3045,NULL,NULL),
	 (2,3046,NULL,NULL),
	 (2,3047,NULL,NULL),
	 (2,3048,NULL,NULL),
	 (2,3049,NULL,NULL),
	 (2,3055,NULL,NULL),
	 (2,3056,NULL,NULL),
	 (2,3057,NULL,NULL),
	 (2,3058,NULL,NULL),
	 (2,3059,NULL,NULL),
	 (2,3065,NULL,NULL),
	 (2,3066,NULL,NULL),
	 (2,3067,NULL,NULL),
	 (2,3068,NULL,NULL),
	 (2,3069,NULL,NULL),
	 (2,3075,NULL,NULL),
	 (2,3076,NULL,NULL),
	 (2,3078,NULL,NULL),
	 (2,3079,NULL,NULL),
	 (2,3080,NULL,NULL),
	 (2,3081,NULL,NULL),
	 (2,3082,NULL,NULL),
	 (2,3083,NULL,NULL),
	 (2,3084,NULL,NULL),
	 (3,3055,NULL,NULL),
	 (3,3056,NULL,NULL),
	 (3,3057,NULL,NULL),
	 (3,3058,NULL,NULL),
	 (3,3059,NULL,NULL);

	 INSERT INTO acl.acl_roles (created_by_id,updated_by_id,title,name,status,company_id,created_at,updated_at) VALUES
	 (NULL,NULL,'super-super-admin','',1,1,'2019-03-21 20:38:30','2015-11-09 07:17:00'),
	 (NULL,NULL,'ADMIN_ROLE',NULL,1,2,'2024-03-07 13:25:44','2024-03-07 13:25:44'),
	 (NULL,NULL,'Only Role Access','Test Name',1,2,'2024-03-07 13:27:31','2024-03-07 13:27:31');

	 INSERT INTO acl.acl_sub_modules (id,module_id,name,controller_name,icon,sequence,created_at,updated_at,default_method,display_name) VALUES
	 (2001,1001,'Company Management','CompanyController','<i class="fa fa-angle-double-right"></i>',100,'2015-12-09 12:10:47','2015-12-09 12:10:47','index','Company Management'),
	 (2020,1002,'Module Management','ModuleController','<i class="fa fa-angle-double-right"></i>',100,'2015-12-09 12:10:48','2015-12-09 12:10:48','index','Module Management'),
	 (2021,1002,'Sub Module Management','SubModuleController','<i class="fa fa-angle-double-right"></i>',101,'2015-12-09 12:10:48','2015-12-09 12:10:48','index','Sub Module Management'),
	 (2022,1002,'Page Management','PageController','<i class="fa fa-angle-double-right"></i>',102,'2015-12-09 12:10:48','2015-12-09 12:10:48','index','Page Management'),
	 (2050,1003,'User Management','UserController','<i class="fa fa-angle-double-right"></i>',18,'2015-12-09 12:10:49','2015-12-09 12:10:49','index','User Management'),
	 (2051,1003,'Role Management','RoleController','<i class="fa fa-angle-double-right"></i>',101,'2015-12-09 12:10:49','2015-12-23 14:35:45','index','Role Management'),
	 (2052,1003,'User Group Management','UsergroupController','<i class="fa fa-angle-double-right"></i>',102,'2015-12-09 12:10:49','2015-12-09 12:10:49','index','User Group Management'),
	 (2053,1003,'Usergroup & Role Association','UsergroupRoleController','<i class="fa fa-angle-double-right"></i>',103,'2015-12-09 12:10:49','2015-12-09 12:10:49','index','Usergroup & Role Association'),
	 (2054,1003,'Role & Page Association','RolePageController','<i class="fa fa-angle-double-right"></i>',104,'2015-12-09 12:10:50','2015-12-09 12:10:50','index','Role & Page Association'),
	 (2055,1003,'Company Module Management','CompanyModuleController','<i class="fa fa-angle-double-right"></i>',105,'2015-12-09 12:10:48','2015-12-09 12:10:48','index','Company Module Management');

	 INSERT INTO acl.acl_user_usergroups (usergroup_id,user_id,company_id,created_at,updated_at) VALUES
	 (1,1,1,'2024-01-24 07:23:21','2024-01-24 07:23:23'),
	 (2,2,2,'2024-03-07 13:25:44','2024-03-07 13:25:44'),
	 (3,3,2,'2024-03-11 11:28:07','2024-03-11 11:28:07');

	 INSERT INTO acl.acl_usergroup_roles (usergroup_id,role_id,company_id,created_at,updated_at) VALUES
	 (1,1,1,NULL,NULL),
	 (2,2,2,NULL,NULL),
	 (3,3,2,NULL,NULL);

	 INSERT INTO acl.acl_usergroups (group_name,category,dashboard_url,status,company_id,created_at,updated_at) VALUES
	 ('super-super-admin-group',0,NULL,1,1,'2019-03-22 08:38:12','2023-11-01 19:17:00'),
	 ('ADMIN_USERGROUP',0,NULL,1,2,'2024-03-07 13:25:44','2024-03-07 13:25:44'),
	 ('Only Role Group',0,NULL,1,2,'2024-03-07 13:29:22','2024-03-07 13:29:22');

	 INSERT INTO acl.acl_users (first_name,last_name,email,avatar,password,dob,gender,address,city,country,phone,is_admin_verified,user_type,remember_token,created_at,updated_at,activated_at,language,username,img_path,status,company_id,permission_version,otp_channel,login_at,created_by_id,auth_identifier) VALUES
	 ('admin1','admin1','ssadmin@sipay.com.tr','users/admin/c41353d1c1fcbdbd39f96ea46a3f769136952e79.png','$2y$12$31BIO8F6i5yIAix8EA1scuoY39rEEhfzQ5dcKs34SDhhUDuPanNhu','1994-02-22',1,'Dhaka','19',0,'+8801788343704',1,0,'','2018-07-10 16:21:24','2024-03-29 06:14:03',NULL,'en','rajibecbb','storage/users/1/2019-04-18-07-49-28-ba4fe9be59df7b82f8243d2126070d76f5305b3e.png',1,1,1,0,NULL,1,'5d48ab20a156eb12b6795c229e7d51d7'),
	 ('Mahmud','Mahmud','korim@gmail.com',NULL,'$2y$12$6A8S6CtoasW/SwZ9GxBMSubVA3UYiF8NBCD21IyHbGbsSwqbXHP8W',NULL,NULL,NULL,NULL,0,NULL,0,1,NULL,'2024-03-07 13:25:44','2024-03-27 03:32:32',NULL,'en',NULL,NULL,1,2,0,0,NULL,1,'5f645f9e65171e3a37eaeb1db911bdc6'),
	 ('pulak','deb','test@usergroup.com','test','$2y$12$Pz/nLPAhUdFpMX.GK1G9oO1GR7OEg0k6RGWBV7JUDE1VFnEdbYjYC','2024-05-10',1,'test','test',1,'014785',0,2,NULL,'2024-03-11 11:28:07','2024-03-12 03:13:48',NULL,'en','pulakdeb',NULL,1,2,0,0,NULL,2,'6041c42ae3c9b0b2481081e2912f5eb5');

	 INSERT INTO acl.acl_usertype_submodules (user_type_id,sub_module_id,created_at,updated_at) VALUES
	 (0,2001,NULL,NULL),
	 (0,2020,NULL,NULL),
	 (0,2021,NULL,NULL),
	 (0,2022,NULL,NULL),
	 (1,2050,NULL,NULL),
	 (1,2051,NULL,NULL),
	 (1,2052,NULL,NULL),
	 (1,2053,NULL,NULL),
	 (1,2054,NULL,NULL);

	 INSERT INTO acl.migrations (migration,batch) VALUES
	 ('2019_08_19_000000_create_failed_jobs_table',1),
	 ('2019_12_14_000001_create_personal_access_tokens_table',1),
	 ('2024_02_01_074121_create_acl_companies_table',1),
	 ('2024_02_01_074559_create_acl_modules_table',1),
	 ('2024_02_01_075124_create_acl_pages_table',1),
	 ('2024_02_01_083352_create_acl_roles_table',1),
	 ('2024_02_01_083523_create_acl_role_pages_table',1),
	 ('2024_02_01_083652_create_acl_sub_modules_table',1),
	 ('2024_02_01_083913_create_acl_usergroups_table',1),
	 ('2024_02_01_084022_create_acl_usergroup_roles_table',1),
	 ('2024_02_01_084138_create_acl_users_table',1),
	 ('2024_02_01_084412_create_acl_usertype_submodules_table',1),
	 ('2024_02_01_084555_create_acl_user_usergroups_table',1),
	 ('2024_02_02_054930_create_acl_page_routes_table',1),
	 ('2024_03_04_111514_create_acl_company_modules_table',1),
	 ('2024_03_04_120334_add_unique_column_to_acl_companies_table',1),
	 ('2024_03_04_120632_drop_acl_users_email_unique_index',1);
