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