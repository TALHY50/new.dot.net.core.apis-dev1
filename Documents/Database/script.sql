30-08-2024
===========================================
ALTER TABLE `imt_mtts` CHANGE `transaction_type_id` `transaction_type_id` INT(10) UNSIGNED NOT NULL;
01-09-2024
============================================
drop table if exists imt_countries;
CREATE TABLE `imt_countries` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `iso_code` varchar(3) DEFAULT NULL,
  `iso_code_short` varchar(2) DEFAULT NULL,
  `iso_code_num` varchar(3) NOT NULL,
  `name` varchar(100) DEFAULT NULL,
  `official_state_name` varchar(100) DEFAULT NULL,
  `created_by_id` int(10) unsigned DEFAULT NULL,
  `updated_by_id` int(10) unsigned DEFAULT NULL,
  `status` tinyint(3) unsigned DEFAULT 1 COMMENT '1=active, 0=inactive, 2=soft-deleted',
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
);


CREATE TABLE `acl_user_settings` (
  `id` int(10) unsigned NOT NULL COMMENT 'id of users table',
  `user_id` int(10) unsigned NOT NULL COMMENT 'id of users table',
  `app_id` varchar(50) NOT NULL,
  `app_secret` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci

05-09-2024
==============================================
drob table if exists acl_users;
CREATE TABLE `acl_users` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `first_name` varchar(100) DEFAULT NULL,
  `last_name` varchar(100) DEFAULT NULL,
  `email` varchar(50) NOT NULL,
  `avatar` varchar(255) DEFAULT NULL,
  `password` varchar(255) DEFAULT NULL,
  `salt` varchar(100) DEFAULT NULL,
  `dob` date DEFAULT NULL,
  `gender` tinyint(4) DEFAULT NULL COMMENT '1=Male, 2=Female',
  `address` varchar(255) DEFAULT NULL,
  `city` varchar(100) DEFAULT NULL,
  `country` int(10) unsigned NOT NULL DEFAULT 0,
  `phone` varchar(20) DEFAULT NULL,
  `is_admin_verified` tinyint(4) NOT NULL DEFAULT 0 COMMENT '0=Pending, 1=Approved, 2=Not Approved, 3=Lock User',
  `user_type` int(10) unsigned NOT NULL DEFAULT 0 COMMENT 'USER_TYPE_SS_ADMIN = 0; USER_TYPE_S_ADMIN = 1; USER_TYPE_USER = 2',
  `remember_token` varchar(100) DEFAULT NULL,
  `refresh_token` varchar(300) DEFAULT NULL,
  `claims` varchar(3000) DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  `activated_at` datetime DEFAULT NULL,
  `language` varchar(2) NOT NULL DEFAULT 'en',
  `username` varchar(50) DEFAULT NULL,
  `img_path` text DEFAULT NULL,
  `status` tinyint(4) NOT NULL DEFAULT 1 COMMENT '0=>Inactive or disable; 1=>enable or active; 2=> disabled or suspected;3= awaiting disable or banned;4=awaiting GSM',
  `company_id` int(10) unsigned NOT NULL DEFAULT 0,
  `permission_version` int(10) unsigned NOT NULL DEFAULT 0,
  `otp_channel` tinyint(4) NOT NULL DEFAULT 0 COMMENT '0 => all channel like sms, email, 1 => only sms, 2=> only email',
  `login_at` datetime DEFAULT NULL COMMENT 'user logged in time',
  `created_by_id` int(10) unsigned NOT NULL DEFAULT 0,
  `auth_identifier` varchar(150) DEFAULT NULL,
  `normalized_user_name` varchar(256) DEFAULT NULL,
  `normalized_email` varchar(256) DEFAULT NULL,
  `email_confirmed` tinyint(1) NOT NULL,
  `password_hash` longtext DEFAULT NULL,
  `security_stamp` longtext DEFAULT NULL,
  `concurrency_stamp` longtext DEFAULT NULL,
  `phone_number` longtext DEFAULT NULL,
  `phone_number_confirmed` tinyint(1) DEFAULT 0,
  `two_factor_enabled` tinyint(1) NOT NULL,
  `lockout_end` datetime DEFAULT NULL,
  `lockout_enabled` tinyint(1) DEFAULT 0,
  `access_failed_count` int(11) NOT NULL DEFAULT 0,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci

ALTER TABLE acl_roles
  ADD `normalized_name` varchar(256) DEFAULT NULL,
  ADD `concurrency_stamp` longtext DEFAULT NULL;