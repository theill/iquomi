IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'iquomi')
	DROP DATABASE [iquomi]
GO

CREATE DATABASE [iquomi]  ON (NAME = N'iquomi', FILENAME = N'I:\Program Files\Microsoft SQL Server\MSSQL$WEBDB\Data\iquomi.mdf' , SIZE = 4, FILEGROWTH = 10%) LOG ON (NAME = N'iquomi_log', FILENAME = N'I:\Program Files\Microsoft SQL Server\MSSQL$WEBDB\Data\iquomi_log.LDF' , FILEGROWTH = 10%)
 COLLATE SQL_Latin1_General_CP1_CI_AS
GO

exec sp_dboption N'iquomi', N'autoclose', N'true'
GO

exec sp_dboption N'iquomi', N'bulkcopy', N'false'
GO

exec sp_dboption N'iquomi', N'trunc. log', N'true'
GO

exec sp_dboption N'iquomi', N'torn page detection', N'true'
GO

exec sp_dboption N'iquomi', N'read only', N'false'
GO

exec sp_dboption N'iquomi', N'dbo use', N'false'
GO

exec sp_dboption N'iquomi', N'single', N'false'
GO

exec sp_dboption N'iquomi', N'autoshrink', N'true'
GO

exec sp_dboption N'iquomi', N'ANSI null default', N'false'
GO

exec sp_dboption N'iquomi', N'recursive triggers', N'false'
GO

exec sp_dboption N'iquomi', N'ANSI nulls', N'false'
GO

exec sp_dboption N'iquomi', N'concat null yields null', N'false'
GO

exec sp_dboption N'iquomi', N'cursor close on commit', N'false'
GO

exec sp_dboption N'iquomi', N'default to local cursor', N'false'
GO

exec sp_dboption N'iquomi', N'quoted identifier', N'false'
GO

exec sp_dboption N'iquomi', N'ANSI warnings', N'false'
GO

exec sp_dboption N'iquomi', N'auto create statistics', N'true'
GO

exec sp_dboption N'iquomi', N'auto update statistics', N'true'
GO

use [iquomi]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_account_account]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[account] DROP CONSTRAINT FK_account_account
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_administrator_account]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[administrator] DROP CONSTRAINT FK_administrator_account
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_author_account]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[author] DROP CONSTRAINT FK_author_account
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_role_account]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[role] DROP CONSTRAINT FK_role_account
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_subscription_account]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[subscription] DROP CONSTRAINT FK_subscription_account
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_subscription_listener_account]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[subscription_listener] DROP CONSTRAINT FK_subscription_listener_account
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_group_administrator_administrator]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[group_administrator] DROP CONSTRAINT FK_group_administrator_administrator
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_service_author]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[service] DROP CONSTRAINT FK_service_author
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_charge_unit_description_charge_unit]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[charge_unit_description] DROP CONSTRAINT FK_charge_unit_description_charge_unit
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_service_charge_charge_unit]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[service_charge] DROP CONSTRAINT FK_service_charge_charge_unit
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_account_group]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[account] DROP CONSTRAINT FK_account_group
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_group_administrator_group]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[group_administrator] DROP CONSTRAINT FK_group_administrator_group
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_charge_unit_description_language]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[charge_unit_description] DROP CONSTRAINT FK_charge_unit_description_language
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_platform_language]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[platform] DROP CONSTRAINT FK_platform_language
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_control_description_language]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[role_description] DROP CONSTRAINT FK_control_description_language
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_access_control_description_language]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[role_template_description] DROP CONSTRAINT FK_access_control_description_language
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_service_description_language]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[service_description] DROP CONSTRAINT FK_service_description_language
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_service_method_method]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[service_method] DROP CONSTRAINT FK_service_method_method
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_method_method_type]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[method] DROP CONSTRAINT FK_method_method_type
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_role_template_method_method_type]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[role_template_method] DROP CONSTRAINT FK_role_template_method_method_type
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_package_item_package]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[package_item] DROP CONSTRAINT FK_package_item_package
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_package_item_remote_package]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[package_item_remote] DROP CONSTRAINT FK_package_item_remote_package
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_package_platform]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[package] DROP CONSTRAINT FK_package_platform
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_role_description_role]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[role_description] DROP CONSTRAINT FK_role_description_role
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_role_role_template]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[role] DROP CONSTRAINT FK_role_role_template
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_role_template_role_template_description]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[role_template_description] DROP CONSTRAINT FK_role_template_role_template_description
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_role_template_method_role_template]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[role_template_method] DROP CONSTRAINT FK_role_template_method_role_template
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_role_scope]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[role] DROP CONSTRAINT FK_role_scope
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_access_control_action_scope]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[role_template_method] DROP CONSTRAINT FK_access_control_action_scope
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_service_scope_scope]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[service_scope] DROP CONSTRAINT FK_service_scope_scope
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_shape_scope]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[shape] DROP CONSTRAINT FK_shape_scope
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_subscription_scope_scope]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[subscription_scope] DROP CONSTRAINT FK_subscription_scope_scope
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_package_service]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[package] DROP CONSTRAINT FK_package_service
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_role_template_service]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[role_template] DROP CONSTRAINT FK_role_template_service
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_service_charge_service]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[service_charge] DROP CONSTRAINT FK_service_charge_service
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_service_dependency_service]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[service_dependency] DROP CONSTRAINT FK_service_dependency_service
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_service_dependency_service1]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[service_dependency] DROP CONSTRAINT FK_service_dependency_service1
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_service_description_service]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[service_description] DROP CONSTRAINT FK_service_description_service
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_service_method_service]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[service_method] DROP CONSTRAINT FK_service_method_service
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_service_scope_service]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[service_scope] DROP CONSTRAINT FK_service_scope_service
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_subscription_service]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[subscription] DROP CONSTRAINT FK_subscription_service
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_subscription_charge_service_charge]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[subscription_charge] DROP CONSTRAINT FK_subscription_charge_service_charge
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_delete_log_subscription]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[delete_log] DROP CONSTRAINT FK_delete_log_subscription
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_subscription_listener_subscription]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[subscription_listener] DROP CONSTRAINT FK_subscription_listener_subscription
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqGetMethodsByRoleTemplateAsString]') and xtype in (N'FN', N'IF', N'TF'))
drop function [dbo].[iqGetMethodsByRoleTemplateAsString]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqGetShapesByScopeAsString]') and xtype in (N'FN', N'IF', N'TF'))
drop function [dbo].[iqGetShapesByScopeAsString]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetSubscription]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetSubscription]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[LogAction]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[LogAction]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqCreateAccount]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqCreateAccount]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqCreateAuthor]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqCreateAuthor]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqCreateDeleteLog]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqCreateDeleteLog]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqCreateMethodHistory]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqCreateMethodHistory]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqCreatePackage]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqCreatePackage]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqCreatePackageItem]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqCreatePackageItem]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqCreateRole]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqCreateRole]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqCreateRoleTemplate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqCreateRoleTemplate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqCreateRoleTemplateDescription]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqCreateRoleTemplateDescription]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqCreateRoleTemplateMethod]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqCreateRoleTemplateMethod]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqCreateScope]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqCreateScope]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqCreateScopeByService]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqCreateScopeByService]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqCreateService]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqCreateService]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqCreateServiceCharge]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqCreateServiceCharge]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqCreateServiceScope]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqCreateServiceScope]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqCreateShape]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqCreateShape]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqCreateSubscription]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqCreateSubscription]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqCreateSubscriptionListener]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqCreateSubscriptionListener]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqCreateSubscriptionScope]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqCreateSubscriptionScope]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqDeleteAccount]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqDeleteAccount]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqDeleteAuthor]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqDeleteAuthor]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqDeleteDeleteLog]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqDeleteDeleteLog]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqDeletePackageItem]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqDeletePackageItem]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqDeleteRole]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqDeleteRole]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqDeleteRoleTemplate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqDeleteRoleTemplate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqDeleteRoleTemplateMethod]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqDeleteRoleTemplateMethod]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqDeleteScope]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqDeleteScope]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqDeleteService]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqDeleteService]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqDeleteServiceCharge]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqDeleteServiceCharge]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqDeleteServiceScope]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqDeleteServiceScope]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqDeleteShape]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqDeleteShape]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqDeleteSubscription]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqDeleteSubscription]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqDeleteSubscriptionListener]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqDeleteSubscriptionListener]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqDeleteSubscriptionScope]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqDeleteSubscriptionScope]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqFindAccountByEmailPassword]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqFindAccountByEmailPassword]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqFindAccountByIqid]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqFindAccountByIqid]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqFindAllAuthorPackages]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqFindAllAuthorPackages]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqFindAllChargeUnits]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqFindAllChargeUnits]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqFindAllDeleteLogs]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqFindAllDeleteLogs]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqFindAllListenersBySubscription]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqFindAllListenersBySubscription]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqFindAllMethodHistories]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqFindAllMethodHistories]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqFindAllMethodTypes]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqFindAllMethodTypes]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqFindAllPackageItemsFull]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqFindAllPackageItemsFull]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqFindAllPackageItemsPartial]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqFindAllPackageItemsPartial]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqFindAllRoleTemplateDescriptions]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqFindAllRoleTemplateDescriptions]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqFindAllRoleTemplateMethods]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqFindAllRoleTemplateMethods]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqFindAllRoleTemplateMethodsByRoleTemplate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqFindAllRoleTemplateMethodsByRoleTemplate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqFindAllRoleTemplatesByService]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqFindAllRoleTemplatesByService]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqFindAllRolesBySubscription]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqFindAllRolesBySubscription]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqFindAllScopesByService]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqFindAllScopesByService]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqFindAllScopesBySubscription]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqFindAllScopesBySubscription]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqFindAllServiceChargesByServiceId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqFindAllServiceChargesByServiceId]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqFindAllServicesByAuthorId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqFindAllServicesByAuthorId]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqFindAllShapesByScope]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqFindAllShapesByScope]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqFindLatestPackage]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqFindLatestPackage]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqFindServiceByAuthor]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqFindServiceByAuthor]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqFindServiceByName]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqFindServiceByName]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqFindSubscriptionByAccountService]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqFindSubscriptionByAccountService]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqListAllLanguages]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqListAllLanguages]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqListAllRoleTemplateMethods]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqListAllRoleTemplateMethods]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqListAllRoleTemplatesByService]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqListAllRoleTemplatesByService]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqListAllScopesByService]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqListAllScopesByService]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqListAllScopesBySubscription]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqListAllScopesBySubscription]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqListAllScopesForSubscription]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqListAllScopesForSubscription]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqListAllServiceChargesByService]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqListAllServiceChargesByService]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqListListenersBySubscription]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqListListenersBySubscription]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqListMySubscriptions]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqListMySubscriptions]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqListProvisionedServices]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqListProvisionedServices]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqListRolesBySubscription]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqListRolesBySubscription]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqListServiceScopes]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqListServiceScopes]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqLookupAuthor]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqLookupAuthor]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqLookupRole]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqLookupRole]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqLookupScopeByMethodTypeId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqLookupScopeByMethodTypeId]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqReadAccount]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqReadAccount]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqReadMethodType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqReadMethodType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqReadPackage]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqReadPackage]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqReadPackageItem]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqReadPackageItem]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqReadRole]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqReadRole]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqReadRoleTemplate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqReadRoleTemplate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqReadRoleTemplateMethod]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqReadRoleTemplateMethod]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqReadScope]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqReadScope]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqReadService]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqReadService]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqReadServiceCharge]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqReadServiceCharge]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqReadShape]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqReadShape]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqReadSubscription]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqReadSubscription]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqReadSubscriptionListener]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqReadSubscriptionListener]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqServiceUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqServiceUpdate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqSubscriptionServices]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqSubscriptionServices]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqUpdateAccount]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqUpdateAccount]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqUpdateRole]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqUpdateRole]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqUpdateRoleTemplate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqUpdateRoleTemplate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqUpdateRoleTemplateDescription]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqUpdateRoleTemplateDescription]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqUpdateRoleTemplateMethod]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqUpdateRoleTemplateMethod]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqUpdateScope]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqUpdateScope]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqUpdateService]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqUpdateService]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqUpdateServiceCharge]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqUpdateServiceCharge]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqUpdateShape]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqUpdateShape]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqUpdateSubscription]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqUpdateSubscription]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[iqUpdateSubscriptionListener]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[iqUpdateSubscriptionListener]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[account]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[account]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[activity]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[activity]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[administrator]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[administrator]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[author]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[author]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[charge_unit]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[charge_unit]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[charge_unit_description]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[charge_unit_description]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[delete_log]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[delete_log]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[group]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[group]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[group_administrator]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[group_administrator]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[history]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[history]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[language]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[language]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[method]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[method]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[method_history]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[method_history]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[method_type]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[method_type]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[package]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[package]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[package_item]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[package_item]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[package_item_remote]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[package_item_remote]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[platform]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[platform]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[role]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[role]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[role_description]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[role_description]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[role_template]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[role_template]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[role_template_description]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[role_template_description]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[role_template_method]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[role_template_method]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[scope]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[scope]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[service]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[service]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[service_charge]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[service_charge]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[service_dependency]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[service_dependency]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[service_description]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[service_description]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[service_method]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[service_method]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[service_scope]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[service_scope]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[shape]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[shape]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[subscription]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[subscription]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[subscription_charge]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[subscription_charge]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[subscription_listener]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[subscription_listener]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[subscription_scope]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[subscription_scope]
GO

CREATE TABLE [dbo].[account] (
	[id] [int] IDENTITY (1, 1) NOT NULL ,
	[owner_account_id] [int] NULL ,
	[group_id] [int] NULL ,
	[iqid] [nvarchar] (128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[email] [nvarchar] (128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[password] [nvarchar] (128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[activity] (
	[subscription_id] [int] NOT NULL ,
	[timestamp] [datetime] NOT NULL ,
	[client_ip] [nvarchar] (32) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[action] [char] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[agent_type] [nvarchar] (32) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[administrator] (
	[id] [int] NOT NULL ,
	[account_id] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[author] (
	[id] [int] IDENTITY (1, 1) NOT NULL ,
	[account_id] [int] NOT NULL ,
	[name] [nvarchar] (64) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[charge_unit] (
	[id] [int] IDENTITY (1, 1) NOT NULL ,
	[common_name] [nvarchar] (128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[charge_unit_description] (
	[charge_unit_id] [int] NOT NULL ,
	[language_id] [int] NOT NULL ,
	[name] [nvarchar] (128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[description] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[delete_log] (
	[subscription_id] [uniqueidentifier] NOT NULL ,
	[instance_id] [varchar] (40) COLLATE SQL_Latin1_General_CP1_CI_AS ,
	[change_number] [varchar] (24) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[uuid] [uniqueidentifier] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[group] (
	[id] [int] NOT NULL ,
	[language_id] [int] NOT NULL ,
	[parent_id] [int] NULL ,
	[name] [nvarchar] (64) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[description] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[group_administrator] (
	[group_id] [int] NOT NULL ,
	[administrator_id] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[history] (
	[id] [int] IDENTITY (1, 1) NOT NULL ,
	[service_id] [int] NOT NULL ,
	[account_id] [int] NOT NULL ,
	[timestamp] [datetime] NOT NULL ,
	[client_ip] [nvarchar] (32) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[action] [char] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[price] [decimal](4, 0) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[language] (
	[id] [int] IDENTITY (1, 1) NOT NULL ,
	[name] [nvarchar] (64) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[method] (
	[id] [int] NOT NULL ,
	[method_type_id] [int] NOT NULL ,
	[script] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[method_history] (
	[id] [int] IDENTITY (1, 1) NOT NULL ,
	[account_id] [int] NOT NULL ,
	[subscription_id] [uniqueidentifier] NOT NULL ,
	[timestamp] [datetime] NOT NULL ,
	[method] [nvarchar] (64) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[method_type] (
	[id] [int] IDENTITY (100, 1) NOT NULL ,
	[name] [nvarchar] (64) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[package] (
	[id] [int] IDENTITY (1, 1) NOT NULL ,
	[service_id] [int] NOT NULL ,
	[platform_id] [int] NOT NULL ,
	[version] [nvarchar] (16) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[release_date] [datetime] NOT NULL ,
	[state] [char] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[package_item] (
	[id] [int] IDENTITY (1, 1) NOT NULL ,
	[package_id] [int] NOT NULL ,
	[name] [nvarchar] (128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[type] [nvarchar] (128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[size] [int] NOT NULL ,
	[data] [image] NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[package_item_remote] (
	[id] [int] NOT NULL ,
	[package_id] [int] NOT NULL ,
	[uri] [nvarchar] (256) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[recurrence_id] [int] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[platform] (
	[id] [int] IDENTITY (1, 1) NOT NULL ,
	[language_id] [int] NOT NULL ,
	[name] [nvarchar] (128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[role] (
	[id] [int] IDENTITY (1, 1) NOT NULL ,
	[subscription_id] [uniqueidentifier] NOT NULL ,
	[account_id] [int] NOT NULL ,
	[scope_id] [int] NULL ,
	[role_template_id] [int] NOT NULL ,
	[active_from] [datetime] NULL ,
	[active_to] [datetime] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[role_description] (
	[role_id] [int] NOT NULL ,
	[language_id] [int] NOT NULL ,
	[description] [nvarchar] (64) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[role_template] (
	[id] [int] IDENTITY (100, 1) NOT NULL ,
	[service_id] [int] NOT NULL ,
	[name] [nvarchar] (64) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[priority] [smallint] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[role_template_description] (
	[role_template_id] [int] NOT NULL ,
	[language_id] [int] NOT NULL ,
	[description] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[role_template_method] (
	[role_template_id] [int] NOT NULL ,
	[method_type_id] [int] NOT NULL ,
	[scope_id] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[scope] (
	[id] [int] IDENTITY (100, 1) NOT NULL ,
	[language_id] [int] NOT NULL ,
	[name] [nvarchar] (128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[base] [nvarchar] (3) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[service] (
	[id] [int] IDENTITY (1, 1) NOT NULL ,
	[author_id] [int] NOT NULL ,
	[name] [nvarchar] (64) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[version] [nvarchar] (16) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[xsd] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[url_xsd] [nvarchar] (160) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[url_icon] [nvarchar] (128) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[url_homepage] [nvarchar] (128) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[state] [char] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[role_map] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[service_charge] (
	[id] [int] IDENTITY (1, 1) NOT NULL ,
	[service_id] [int] NOT NULL ,
	[method_type_id] [int] NOT NULL ,
	[schema_type] [nvarchar] (64) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[script] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[price] [real] NOT NULL ,
	[charge_unit_id] [int] NOT NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[service_dependency] (
	[service_id] [int] NOT NULL ,
	[dependency_service_id] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[service_description] (
	[service_id] [int] NOT NULL ,
	[language_id] [int] NOT NULL ,
	[short_description] [nvarchar] (256) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[long_description] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[service_method] (
	[service_id] [int] NOT NULL ,
	[method_id] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[service_scope] (
	[service_id] [int] NOT NULL ,
	[scope_id] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[shape] (
	[id] [int] IDENTITY (1, 1) NOT NULL ,
	[scope_id] [int] NOT NULL ,
	[select] [nvarchar] (64) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[type] [nchar] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[subscription] (
	[id] [uniqueidentifier] NOT NULL ,
	[account_id] [int] NOT NULL ,
	[service_id] [int] NOT NULL ,
	[xml] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[role_list] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[notify_list] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[subscription_charge] (
	[subscription_id] [uniqueidentifier] NOT NULL ,
	[service_charge_id] [int] NOT NULL ,
	[timestamp] [datetime] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[subscription_listener] (
	[id] [int] IDENTITY (1, 1) NOT NULL ,
	[account_id] [int] NOT NULL ,
	[subscription_id] [uniqueidentifier] NOT NULL ,
	[filter] [nvarchar] (128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[context] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[context_uri] [nvarchar] (128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[to] [nvarchar] (128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[active_from] [datetime] NULL ,
	[active_to] [datetime] NULL ,
	[state] [char] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[subscription_scope] (
	[subscription_id] [uniqueidentifier] NOT NULL ,
	[scope_id] [int] NOT NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[account] WITH NOCHECK ADD 
	CONSTRAINT [PK_account] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[administrator] WITH NOCHECK ADD 
	CONSTRAINT [PK_administrator] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[author] WITH NOCHECK ADD 
	CONSTRAINT [PK_author] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[charge_unit] WITH NOCHECK ADD 
	CONSTRAINT [PK_charge_unit] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[charge_unit_description] WITH NOCHECK ADD 
	CONSTRAINT [PK_charge_unit_description] PRIMARY KEY  CLUSTERED 
	(
		[charge_unit_id],
		[language_id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[delete_log] WITH NOCHECK ADD 
	CONSTRAINT [PK_delete_log] PRIMARY KEY  CLUSTERED 
	(
		[subscription_id],
		[change_number],
		[uuid]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[group] WITH NOCHECK ADD 
	CONSTRAINT [PK_group] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[group_administrator] WITH NOCHECK ADD 
	CONSTRAINT [PK_group_administrator] PRIMARY KEY  CLUSTERED 
	(
		[group_id],
		[administrator_id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[history] WITH NOCHECK ADD 
	CONSTRAINT [PK_report] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[language] WITH NOCHECK ADD 
	CONSTRAINT [PK_language] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[method] WITH NOCHECK ADD 
	CONSTRAINT [PK_action] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[method_history] WITH NOCHECK ADD 
	CONSTRAINT [PK_method_history] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[method_type] WITH NOCHECK ADD 
	CONSTRAINT [PK_action_type] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[package] WITH NOCHECK ADD 
	CONSTRAINT [PK_package] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[package_item] WITH NOCHECK ADD 
	CONSTRAINT [PK_package_item] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[package_item_remote] WITH NOCHECK ADD 
	CONSTRAINT [PK_package_item_remote] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[platform] WITH NOCHECK ADD 
	CONSTRAINT [PK_platform] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[role] WITH NOCHECK ADD 
	CONSTRAINT [PK_control] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[role_description] WITH NOCHECK ADD 
	CONSTRAINT [PK_control_description] PRIMARY KEY  CLUSTERED 
	(
		[role_id],
		[language_id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[role_template] WITH NOCHECK ADD 
	CONSTRAINT [PK_access_control] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[role_template_description] WITH NOCHECK ADD 
	CONSTRAINT [PK_access_control_description] PRIMARY KEY  CLUSTERED 
	(
		[role_template_id],
		[language_id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[role_template_method] WITH NOCHECK ADD 
	CONSTRAINT [PK_access_control_action] PRIMARY KEY  CLUSTERED 
	(
		[role_template_id],
		[method_type_id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[scope] WITH NOCHECK ADD 
	CONSTRAINT [PK_scope] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[service] WITH NOCHECK ADD 
	CONSTRAINT [PK_service] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[service_charge] WITH NOCHECK ADD 
	CONSTRAINT [PK_service_charge] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[service_dependency] WITH NOCHECK ADD 
	CONSTRAINT [PK_service_dependency] PRIMARY KEY  CLUSTERED 
	(
		[service_id],
		[dependency_service_id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[service_description] WITH NOCHECK ADD 
	CONSTRAINT [PK_service_description] PRIMARY KEY  CLUSTERED 
	(
		[service_id],
		[language_id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[service_method] WITH NOCHECK ADD 
	CONSTRAINT [PK_service_method] PRIMARY KEY  CLUSTERED 
	(
		[service_id],
		[method_id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[service_scope] WITH NOCHECK ADD 
	CONSTRAINT [PK_service_scope] PRIMARY KEY  CLUSTERED 
	(
		[service_id],
		[scope_id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[shape] WITH NOCHECK ADD 
	CONSTRAINT [PK_scope_modifier] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[subscription] WITH NOCHECK ADD 
	CONSTRAINT [PK_subscription] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[subscription_listener] WITH NOCHECK ADD 
	CONSTRAINT [PK_subscription_listener] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[subscription_scope] WITH NOCHECK ADD 
	CONSTRAINT [PK_subscription_scope] PRIMARY KEY  CLUSTERED 
	(
		[subscription_id],
		[scope_id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[account] WITH NOCHECK ADD 
	CONSTRAINT [IX_account] UNIQUE  NONCLUSTERED 
	(
		[email]
	)  ON [PRIMARY] ,
	CONSTRAINT [IX_iqid] UNIQUE  NONCLUSTERED 
	(
		[iqid]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[package] WITH NOCHECK ADD 
	CONSTRAINT [DF_package_platform_id] DEFAULT (1) FOR [platform_id],
	CONSTRAINT [DF_package_state] DEFAULT ('N') FOR [state]
GO

ALTER TABLE [dbo].[scope] WITH NOCHECK ADD 
	CONSTRAINT [DF_scope_language_id] DEFAULT (1) FOR [language_id],
	CONSTRAINT [DF_scope_base] DEFAULT (N'NIL') FOR [base]
GO

ALTER TABLE [dbo].[service] WITH NOCHECK ADD 
	CONSTRAINT [DF_service_state] DEFAULT ('N') FOR [state],
	CONSTRAINT [IX_service] UNIQUE  NONCLUSTERED 
	(
		[name]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[subscription] WITH NOCHECK ADD 
	CONSTRAINT [IX_subscription] UNIQUE  NONCLUSTERED 
	(
		[account_id],
		[service_id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[subscription_listener] WITH NOCHECK ADD 
	CONSTRAINT [DF_subscription_listener_state] DEFAULT ('R') FOR [state]
GO

ALTER TABLE [dbo].[account] ADD 
	CONSTRAINT [FK_account_account] FOREIGN KEY 
	(
		[owner_account_id]
	) REFERENCES [dbo].[account] (
		[id]
	),
	CONSTRAINT [FK_account_group] FOREIGN KEY 
	(
		[group_id]
	) REFERENCES [dbo].[group] (
		[id]
	)
GO

ALTER TABLE [dbo].[administrator] ADD 
	CONSTRAINT [FK_administrator_account] FOREIGN KEY 
	(
		[account_id]
	) REFERENCES [dbo].[account] (
		[id]
	)
GO

ALTER TABLE [dbo].[author] ADD 
	CONSTRAINT [FK_author_account] FOREIGN KEY 
	(
		[account_id]
	) REFERENCES [dbo].[account] (
		[id]
	) ON DELETE CASCADE 
GO

ALTER TABLE [dbo].[charge_unit_description] ADD 
	CONSTRAINT [FK_charge_unit_description_charge_unit] FOREIGN KEY 
	(
		[charge_unit_id]
	) REFERENCES [dbo].[charge_unit] (
		[id]
	),
	CONSTRAINT [FK_charge_unit_description_language] FOREIGN KEY 
	(
		[language_id]
	) REFERENCES [dbo].[language] (
		[id]
	)
GO

ALTER TABLE [dbo].[delete_log] ADD 
	CONSTRAINT [FK_delete_log_subscription] FOREIGN KEY 
	(
		[subscription_id]
	) REFERENCES [dbo].[subscription] (
		[id]
	) ON DELETE CASCADE 
GO

ALTER TABLE [dbo].[group_administrator] ADD 
	CONSTRAINT [FK_group_administrator_administrator] FOREIGN KEY 
	(
		[administrator_id]
	) REFERENCES [dbo].[administrator] (
		[id]
	),
	CONSTRAINT [FK_group_administrator_group] FOREIGN KEY 
	(
		[group_id]
	) REFERENCES [dbo].[group] (
		[id]
	)
GO

ALTER TABLE [dbo].[method] ADD 
	CONSTRAINT [FK_method_method_type] FOREIGN KEY 
	(
		[method_type_id]
	) REFERENCES [dbo].[method_type] (
		[id]
	)
GO

ALTER TABLE [dbo].[package] ADD 
	CONSTRAINT [FK_package_platform] FOREIGN KEY 
	(
		[platform_id]
	) REFERENCES [dbo].[platform] (
		[id]
	),
	CONSTRAINT [FK_package_service] FOREIGN KEY 
	(
		[service_id]
	) REFERENCES [dbo].[service] (
		[id]
	) ON DELETE CASCADE 
GO

ALTER TABLE [dbo].[package_item] ADD 
	CONSTRAINT [FK_package_item_package] FOREIGN KEY 
	(
		[package_id]
	) REFERENCES [dbo].[package] (
		[id]
	) ON DELETE CASCADE 
GO

ALTER TABLE [dbo].[package_item_remote] ADD 
	CONSTRAINT [FK_package_item_remote_package] FOREIGN KEY 
	(
		[package_id]
	) REFERENCES [dbo].[package] (
		[id]
	) ON DELETE CASCADE 
GO

ALTER TABLE [dbo].[platform] ADD 
	CONSTRAINT [FK_platform_language] FOREIGN KEY 
	(
		[language_id]
	) REFERENCES [dbo].[language] (
		[id]
	)
GO

ALTER TABLE [dbo].[role] ADD 
	CONSTRAINT [FK_role_account] FOREIGN KEY 
	(
		[account_id]
	) REFERENCES [dbo].[account] (
		[id]
	),
	CONSTRAINT [FK_role_role_template] FOREIGN KEY 
	(
		[role_template_id]
	) REFERENCES [dbo].[role_template] (
		[id]
	) ON DELETE CASCADE ,
	CONSTRAINT [FK_role_scope] FOREIGN KEY 
	(
		[scope_id]
	) REFERENCES [dbo].[scope] (
		[id]
	)
GO

ALTER TABLE [dbo].[role_description] ADD 
	CONSTRAINT [FK_control_description_language] FOREIGN KEY 
	(
		[language_id]
	) REFERENCES [dbo].[language] (
		[id]
	),
	CONSTRAINT [FK_role_description_role] FOREIGN KEY 
	(
		[role_id]
	) REFERENCES [dbo].[role] (
		[id]
	)
GO

ALTER TABLE [dbo].[role_template] ADD 
	CONSTRAINT [FK_role_template_service] FOREIGN KEY 
	(
		[service_id]
	) REFERENCES [dbo].[service] (
		[id]
	) ON DELETE CASCADE 
GO

ALTER TABLE [dbo].[role_template_description] ADD 
	CONSTRAINT [FK_access_control_description_language] FOREIGN KEY 
	(
		[language_id]
	) REFERENCES [dbo].[language] (
		[id]
	),
	CONSTRAINT [FK_role_template_role_template_description] FOREIGN KEY 
	(
		[role_template_id]
	) REFERENCES [dbo].[role_template] (
		[id]
	) ON DELETE CASCADE 
GO

ALTER TABLE [dbo].[role_template_method] ADD 
	CONSTRAINT [FK_access_control_action_scope] FOREIGN KEY 
	(
		[scope_id]
	) REFERENCES [dbo].[scope] (
		[id]
	),
	CONSTRAINT [FK_role_template_method_method_type] FOREIGN KEY 
	(
		[method_type_id]
	) REFERENCES [dbo].[method_type] (
		[id]
	),
	CONSTRAINT [FK_role_template_method_role_template] FOREIGN KEY 
	(
		[role_template_id]
	) REFERENCES [dbo].[role_template] (
		[id]
	) ON DELETE CASCADE 
GO

ALTER TABLE [dbo].[service] ADD 
	CONSTRAINT [FK_service_author] FOREIGN KEY 
	(
		[author_id]
	) REFERENCES [dbo].[author] (
		[id]
	)
GO

ALTER TABLE [dbo].[service_charge] ADD 
	CONSTRAINT [FK_service_charge_charge_unit] FOREIGN KEY 
	(
		[charge_unit_id]
	) REFERENCES [dbo].[charge_unit] (
		[id]
	),
	CONSTRAINT [FK_service_charge_service] FOREIGN KEY 
	(
		[service_id]
	) REFERENCES [dbo].[service] (
		[id]
	) ON DELETE CASCADE 
GO

ALTER TABLE [dbo].[service_dependency] ADD 
	CONSTRAINT [FK_service_dependency_service] FOREIGN KEY 
	(
		[service_id]
	) REFERENCES [dbo].[service] (
		[id]
	),
	CONSTRAINT [FK_service_dependency_service1] FOREIGN KEY 
	(
		[dependency_service_id]
	) REFERENCES [dbo].[service] (
		[id]
	)
GO

ALTER TABLE [dbo].[service_description] ADD 
	CONSTRAINT [FK_service_description_language] FOREIGN KEY 
	(
		[language_id]
	) REFERENCES [dbo].[language] (
		[id]
	),
	CONSTRAINT [FK_service_description_service] FOREIGN KEY 
	(
		[service_id]
	) REFERENCES [dbo].[service] (
		[id]
	)
GO

ALTER TABLE [dbo].[service_method] ADD 
	CONSTRAINT [FK_service_method_method] FOREIGN KEY 
	(
		[method_id]
	) REFERENCES [dbo].[method] (
		[id]
	),
	CONSTRAINT [FK_service_method_service] FOREIGN KEY 
	(
		[service_id]
	) REFERENCES [dbo].[service] (
		[id]
	)
GO

ALTER TABLE [dbo].[service_scope] ADD 
	CONSTRAINT [FK_service_scope_scope] FOREIGN KEY 
	(
		[scope_id]
	) REFERENCES [dbo].[scope] (
		[id]
	) ON DELETE CASCADE ,
	CONSTRAINT [FK_service_scope_service] FOREIGN KEY 
	(
		[service_id]
	) REFERENCES [dbo].[service] (
		[id]
	) ON DELETE CASCADE 
GO

ALTER TABLE [dbo].[shape] ADD 
	CONSTRAINT [FK_shape_scope] FOREIGN KEY 
	(
		[scope_id]
	) REFERENCES [dbo].[scope] (
		[id]
	) ON DELETE CASCADE 
GO

ALTER TABLE [dbo].[subscription] ADD 
	CONSTRAINT [FK_subscription_account] FOREIGN KEY 
	(
		[account_id]
	) REFERENCES [dbo].[account] (
		[id]
	),
	CONSTRAINT [FK_subscription_service] FOREIGN KEY 
	(
		[service_id]
	) REFERENCES [dbo].[service] (
		[id]
	)
GO

ALTER TABLE [dbo].[subscription_charge] ADD 
	CONSTRAINT [FK_subscription_charge_service_charge] FOREIGN KEY 
	(
		[service_charge_id]
	) REFERENCES [dbo].[service_charge] (
		[id]
	)
GO

ALTER TABLE [dbo].[subscription_listener] ADD 
	CONSTRAINT [FK_subscription_listener_account] FOREIGN KEY 
	(
		[account_id]
	) REFERENCES [dbo].[account] (
		[id]
	) ON DELETE CASCADE ,
	CONSTRAINT [FK_subscription_listener_subscription] FOREIGN KEY 
	(
		[subscription_id]
	) REFERENCES [dbo].[subscription] (
		[id]
	) ON DELETE CASCADE 
GO

ALTER TABLE [dbo].[subscription_scope] ADD 
	CONSTRAINT [FK_subscription_scope_scope] FOREIGN KEY 
	(
		[scope_id]
	) REFERENCES [dbo].[scope] (
		[id]
	)
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.GetSubscription (
	@account_id int,
	@service_id int
)

AS

SELECT
	id,
	account_id,
	service_id,
	[xml],
	role_list
	
FROM
	subscription
	
WHERE
	account_id = @account_id AND
	service_id = @service_id
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.LogAction
	(
		@service_id int,
		@account_id int,
		@client_ip nvarchar(32),
		@action char(1)
	)
AS
INSERT INTO history (
	service_id, 
	account_id, 
	[timestamp], 
	client_ip, 
	action, 
	price
)
VALUES (
	@service_id,
	@account_id,
	CURRENT_TIMESTAMP,
	@client_ip,
	@action,
	NULL
)
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqCreateAccount (
	@owner_account_id int,
	@group_id int,
	@iqid nvarchar(128),
	@email nvarchar(128),
	@password nvarchar(128)
)

AS
	
INSERT INTO account (
	owner_account_id, 
	group_id, 
	iqid,
	email, 
	password
) VALUES (
	@owner_account_id, 
	@group_id, 
	@iqid,
	@email, 
	@password
)

SELECT id FROM account WHERE id = @@IDENTITY


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqCreateAuthor (
	@account_id int,
	@name nvarchar(64)
)

AS
	
INSERT INTO author (
	account_id, 
	[name]
) VALUES (
	@account_id, 
	@name
)

SELECT id FROM author WHERE id = @@IDENTITY


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqCreateDeleteLog (
	@subscription_id uniqueidentifier,
	@change_number int,
	@uuid varchar(40)
)

AS

INSERT INTO delete_log (
	subscription_id,
	change_number,
	uuid
)
VALUES (
	@subscription_id,
	@change_number,
	@uuid
)
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--
-- <insertRequest service="myBookmarks" select="//folder[title='Daily Use']" >
--  <bookmark>
--   <title>Iquomi Web Site</title>
--   <url>http://www.iquomi.com/</url>
--  </bookmark>
-- </insertRequest>
--
--
CREATE PROCEDURE dbo.iqCreateMethodHistory (
	@account_id int,
	@subscription_id uniqueidentifier,
	@method nvarchar(64)
)

AS

INSERT INTO method_history (
	account_id,
	subscription_id, 
	[timestamp], 
	method 
)
VALUES (
	@account_id,
	@subscription_id,
	CURRENT_TIMESTAMP,
	@method
)

SELECT id FROM method_history WHERE id = @@IDENTITY
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqCreatePackage (
	@service_id int,
	@version nvarchar(16),
	@release_date datetime,
	@state char(1)
)

AS
	
INSERT INTO package (
	service_id, 
	version, 
	release_date, 
	state
) VALUES (
	@service_id, 
	@version, 
	@release_date, 
	@state
)

SELECT id FROM package WHERE id = @@IDENTITY


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqCreatePackageItem (
	@package_id int,
	@name nvarchar(128),
	@type nvarchar(128),
	@size int,
	@data image	
)

AS

IF (@size = 0) BEGIN
	SET @size = DATALENGTH(@data)
END

INSERT INTO package_item (
	package_id,
	[name],
	type,
	[size],
	data
)
VALUES (
	@package_id,
	@name,
	@type,
	@size,
	@data
)

SELECT id FROM package_item WHERE id = @@IDENTITY
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqCreateRole (
	@subscription_id uniqueidentifier,
	@account_id int,
	@role_template_id int,
	@scope_id int,
	@active_from datetime, 
	@active_to datetime
)

AS

INSERT INTO role (
	subscription_id,
	account_id,
	role_template_id,
	scope_id,
	active_from,
	active_to
)
VALUES (
	@subscription_id,
	@account_id,
	@role_template_id,
	@scope_id,
	@active_from, 
	@active_to
)

SELECT id FROM role WHERE id = @@IDENTITY

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqCreateRoleTemplate (
	@service_id int,
	@name nvarchar(64),
	@priority int
)

AS

INSERT INTO role_template (
	service_id,
	[name],
	priority
)
VALUES (
	@service_id,
	@name,
	@priority
)

SELECT id FROM role_template WHERE id = @@IDENTITY
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqCreateRoleTemplateDescription (
	@role_template_id int,
	@language_id int,
	@description text
)

AS

INSERT INTO role_template_description (
	role_template_id,
	language_id,
	description
)
VALUES (
	@role_template_id,
	@language_id,
	@description
)


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqCreateRoleTemplateMethod (
	@role_template_id int,
	@method_type_id int,
	@scope_id int
)

AS

INSERT INTO role_template_method (
	role_template_id,
	method_type_id,
	scope_id
)
VALUES (
	@role_template_id,
	@method_type_id,
	@scope_id
)

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqCreateScope (
	@language_id int,
	@name nvarchar(128),
	@base nvarchar(3)
)

AS

INSERT INTO scope (
    language_id,
	[name],
	base
)
VALUES (
    @language_id,
	@name,
	@base
)

SELECT id FROM scope WHERE id = @@IDENTITY
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqCreateScopeByService (
	@service_id int,
	@language_id int,
	@name nvarchar(128),
	@base nvarchar(3)
)

AS

-- insert new scope
DECLARE @scope_id int

INSERT INTO scope (
    language_id,
	[name],
	base
)
VALUES (
    @language_id,
	@name,
	@base
)

SET @scope_id = @@IDENTITY

-- insert relation between new scope and existing service
EXEC iqCreateServiceScope @service_id, @scope_id

-- do _not_ use RETURN since code always requires data sets (for more
-- generic handling)
SELECT @scope_id

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqCreateService (
	@author_id int,
	@name nvarchar(64),
	@version nvarchar(16),
	@xsd text,
	@url_xsd nvarchar(320),
	@url_icon nvarchar(128),
	@url_homepage nvarchar(128),
	@state char(1) = 'N',
	@role_map text
)

AS

INSERT INTO service (
	author_id,
	[name],
	version,
	xsd,
	url_xsd,
	url_icon,
	url_homepage,
	state,
	role_map
)
VALUES (
	@author_id,
	@name,
	@version,
	@xsd,
	@url_xsd,
	@url_icon,
	@url_homepage,
	@state,
	@role_map
)

DECLARE @service_id int
SET @service_id = @@IDENTITY

/*
-- declare required cursors
DECLARE csrStandardScope CURSOR FOR
	SELECT	id, [name], base
	FROM	standard_scope
	
DECLARE csrStandardRoleTemplate CURSOR FOR
	SELECT	id, [name], priority
	FROM	standard_role_template


-- setup default role templates for new service
DECLARE
	@role_template_id int,
	@role_template_name nvarchar(64),
	@role_template_priority smallint,
	@standard_role_template_id int

OPEN csrStandardRoleTemplate
FETCH NEXT FROM csrStandardRoleTemplate INTO @standard_role_template_id, @role_template_name, @role_template_priority
WHILE (@@FETCH_STATUS = 0) BEGIN
	
	-- insert role template
	INSERT INTO role_template ([name], priority) VALUES (@role_template_name, @role_template_priority)
	SET @role_template_id = @@IDENTITY
	
	-- insert role template description(s)
	INSERT INTO role_template_description (role_template_id, language_id, description)
	SELECT @role_template_id, language_id, description
	FROM standard_role_template_description
	WHERE standard_role_template_id = @standard_role_template_id
	
	-- setup default scopes for new service
	DECLARE
		@scope_id int,
		@scope_name nvarchar(128),
		@scope_base nvarchar(3),
		@standard_scope_id int
		
	OPEN csrStandardScope
	FETCH NEXT FROM csrStandardScope INTO @standard_scope_id, @scope_name, @scope_base
	WHILE (@@FETCH_STATUS = 0) BEGIN
		INSERT INTO scope ([name], base) VALUES (@scope_name, @scope_base)
		SET @scope_id = @@IDENTITY
		
		INSERT INTO service_scope (
			service_id,
			scope_id
		) VALUES (
			@service_id,
			@scope_id
		)
		
		-- insert role template methods
		INSERT INTO role_template_method (role_template_id, method_type_id, scope_id)
		SELECT	@role_template_id, mt.id, @scope_id
		FROM	standard_role_template_method srtm, method_type mt
		WHERE	srtm.standard_role_template_id = @standard_role_template_id
		AND		srtm.method_type_id = mt.id
		AND		srtm.standard_scope_id = @standard_scope_id
		
		FETCH NEXT FROM csrStandardScope INTO @standard_scope_id, @scope_name, @scope_base
	END
	CLOSE csrStandardScope
	
	-- insert service/role_template mapping
	INSERT INTO role_map (
		service_id,
		role_template_id
	) VALUES (
		@service_id,
		@role_template_id
	)
	
	FETCH NEXT FROM csrStandardRoleTemplate INTO @standard_role_template_id, @role_template_name, @role_template_priority
END

CLOSE csrStandardRoleTemplate
*/

-- return id of new service
SELECT @service_id

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--
-- 
--
CREATE PROCEDURE dbo.iqCreateServiceCharge (
	@service_id int,
	@method_type_id int,
	@schema_type nvarchar(64),
	@script text = NULL,
	@price float,
	@charge_unit_id int
)

AS

INSERT INTO service_charge (
	service_id,
	method_type_id,
	schema_type,
	script,
	price,
	charge_unit_id
)
VALUES (
	@service_id,
	@method_type_id,
	@schema_type,
	@script,
	@price,
	@charge_unit_id
)

SELECT id FROM service_charge WHERE id = @@IDENTITY
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqCreateServiceScope (
	@service_id int,
	@scope_id int
)

AS

INSERT INTO service_scope (
	service_id,
	scope_id
)
VALUES (
	@service_id,
	@scope_id
)

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqCreateShape (
	@scope_id int,
	@select nvarchar(128),
	@type char(1)
)

AS

INSERT INTO shape (
	scope_id,
	[select],
	type
)
VALUES (
	@scope_id,
	@select,
	@type
)

SELECT id FROM shape WHERE id = @@IDENTITY
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--
-- Creates new subscription
--
CREATE PROCEDURE dbo.iqCreateSubscription (
	@id uniqueidentifier,
	@account_id int,
	@service_id int,
	@xml text,
	@role_list text,
	@notify_list text
)

AS

INSERT INTO subscription (
	id,
	account_id,
	service_id,
	[xml],
	role_list,
	notify_list
)
VALUES (
	@id,
	@account_id,
	@service_id,
	@xml,
	@role_list,
	@notify_list
)

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--
-- Creates new subscription listener
--
CREATE PROCEDURE dbo.iqCreateSubscriptionListener (
	@account_id int,
	@subscription_id uniqueidentifier,
	@filter nvarchar(128),
	@context text,
	@context_uri nvarchar(128),
	@to nvarchar(128),
	@active_from datetime, 
	@active_to datetime,
	@state char(1)
)

AS

INSERT INTO subscription_listener (
	account_id,
	subscription_id,
	filter,
	context,
	context_uri,
	[to],
	active_from,
	active_to,
	state
)
VALUES (
	@account_id,
	@subscription_id,
	@filter,
	@context,
	@context_uri,
	@to,
	@active_from, 
	@active_to,
	@state
)

SELECT id FROM subscription_listener WHERE id = @@IDENTITY

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqCreateSubscriptionScope (
	@subscription_id uniqueidentifier,
	@scope_id int
)

AS

INSERT INTO subscription_scope (
	subscription_id,
	scope_id
)
VALUES (
	@subscription_id,
	@scope_id
)

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqDeleteAccount (
	@id int
)

AS

DELETE FROM
	account
	
WHERE
	id = @id
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqDeleteAuthor (
	@id int
)

AS

DELETE FROM
	author
	
WHERE
	id = @id
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqDeleteDeleteLog (
	@instance_id varchar(40),
	@change_number int,
	@uuid varchar(40)
)

AS

DELETE FROM
	delete_log
	
WHERE
	instance_id = @instance_id
AND
	change_number = @change_number
AND
	uuid = @uuid

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqDeletePackageItem (
	@id int
)

AS

DELETE FROM
	package_item
	
WHERE
	id = @id

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqDeleteRole (
	@id int
)

AS

DELETE FROM
	role
	
WHERE
	id = @id
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqDeleteRoleTemplate (
	@id int
)

AS

DELETE FROM
	role_template
	
WHERE
	id = @id

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqDeleteRoleTemplateMethod (
	@role_template_id int,
	@method_type_id int
)

AS

DELETE FROM
	role_template_method
	
WHERE
	role_template_id = @role_template_id
AND
	method_type_id = @method_type_id

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqDeleteScope (
	@id int
)

AS

DELETE FROM
	scope
	
WHERE
	id = @id

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqDeleteService (
	@id int
)

AS

DELETE FROM
	service
	
WHERE
	id = @id

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqDeleteServiceCharge (
	@id int
)

AS

DELETE FROM
	service_charge
	
WHERE
	id = @id
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqDeleteServiceScope (
	@service_id int,
	@scope_id int
)

AS

DELETE FROM
	service_scope
	
WHERE
	service_id = @service_id
AND
	scope_id = @scope_id

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqDeleteShape (
	@id int
)

AS

DELETE FROM
	shape
	
WHERE
	id = @id

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqDeleteSubscription (
	@service_id int,
	@account_id int
)

AS

-- [TO-DO] We need to log this delete request so it's possible to charge 
-- user for the entire period (if selected)

DELETE FROM
	subscription
	
WHERE
	service_id = @service_id
AND
	account_id = @account_id
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqDeleteSubscriptionListener (
	@id int
)

AS

DELETE FROM
	subscription_listener
	
WHERE
	id = @id
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqDeleteSubscriptionScope (
	@subscription_id uniqueidentifier,
	@scope_id int
)

AS

DELETE FROM
	subscription_scope
	
WHERE
	subscription_id = @subscription_id
AND
	scope_id = @scope_id

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqFindAccountByEmailPassword (
	@email nvarchar(128),
	@password nvarchar(128)
)

AS

SELECT
	id,
	owner_account_id,
	group_id,
	iqid,
	email,
	password
	
FROM
	account
	
WHERE
	email = @email
AND
	password = @password

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqFindAccountByIqid (
	@iqid nvarchar(128)
)

AS

SELECT
	id,
	owner_account_id,
	group_id,
	iqid,
	email,
	password
	
FROM
	account
	
WHERE
	iqid = @iqid

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqFindAllAuthorPackages (
	@author_id int
)

AS

SELECT
	s.id				AS ServiceId,
	s.[name]			AS ServiceName,
	s.url_icon			AS ServiceUrlIcon,
	s.url_homepage		AS ServiceUrlHomepage,
	p.id				AS PackageId,
	p.version			AS PackageVersion,
	p.release_date		AS PackageReleaseDate,
	p.state				AS PackageState,
	ISNULL(SUM([pi].size), 0)		AS PackageSize
FROM
	package p LEFT OUTER JOIN 
		package_item [pi]
	ON
		[pi].package_id = p.id,
	service s
WHERE
	p.service_id = s.id
AND
	s.author_id = @author_id
GROUP BY
	s.id, s.[name], s.url_icon, s.url_homepage, p.id, p.version, p.release_date, p.state
ORDER BY
	s.[name]
	
RETURN 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqFindAllChargeUnits (
	@language_id int
)

AS

SELECT
	cu.id				AS ChargeUnitId,
	cu.common_name		AS ChargeUnitCommonName,
	cud.language_id		AS ChargeUnitDescriptionLanguageId,
	cud.[name]			AS ChargeUnitDescriptionName,
	cud.description		AS ChargeUnitDescriptionDescription
FROM
	charge_unit cu, 
	charge_unit_description cud
WHERE
	cu.id = cud.charge_unit_id
AND
	cud.language_id = @language_id
ORDER BY
	cud.[name]
	
RETURN 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqFindAllDeleteLogs (
	@subscription_id uniqueidentifier
)

AS

SELECT
	subscription_id,
	change_number,
	uuid
	
FROM
	delete_log
	
WHERE
	subscription_id = @subscription_id

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqFindAllListenersBySubscription
	@subscription_id uniqueidentifier
AS

SELECT
	id,
	account_id,
	subscription_id,
	filter,
	context,
	context_uri,
	[to],
	state
	
FROM
	subscription_listener
	
WHERE
	subscription_id = @subscription_id

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqFindAllMethodHistories (
	@account_id int,
	@language_id int
)

AS

SELECT
	mh.id									AS MethodHistoryId,
	mh.account_id					AS MethodHistoryAccountId,
	mh.subscription_id		AS MethodHistorySubscriptionId,
	mh.[timestamp]				AS MethodHistoryTimestamp,
	mh.method							AS MethodHistoryMethod,
	s.id									AS ServiceId,
	s.name								AS ServiceName,
	s.version							AS ServiceVersion,
	s.url_icon						AS ServiceUrlIcon,
	sd.short_description	AS ServiceShortDescription,
	a.iqid								AS AccountIqid,
	a.email								AS AccountEmail
FROM
	method_history mh,
	subscription sub,
	account a,
	service s LEFT OUTER JOIN
		service_description sd
	ON
		s.id = sd.service_id
	AND
		sd.language_id = @language_id
WHERE
	sub.account_id = @account_id
AND
	s.id = sub.service_id
AND
	mh.subscription_id = sub.id
AND
	a.id = mh.account_id
ORDER BY
	mh.[timestamp] DESC
	
RETURN 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqFindAllMethodTypes
AS

SELECT
	id,
	[name]
FROM
	method_type
ORDER BY
	[name]
	
RETURN 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqFindAllPackageItemsFull (
	@package_id int
)

AS

SELECT
	id				AS PackageItemId,
	package_id		AS PackageItemPackageId,
	[name]			AS PackageItemName,
	type			AS PackageItemType,
	[size]			AS PackageItemSize,
	data			AS PackageItemData
	
FROM
	package_item
	
WHERE
	package_id = @package_id
	
ORDER BY
	[name], type
		
RETURN 
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqFindAllPackageItemsPartial (
	@package_id int
)

AS

SELECT
	id				AS PackageItemId,
	package_id		AS PackageItemPackageId,
	[name]			AS PackageItemName,
	type			AS PackageItemType,
	[size]			AS PackageItemSize
FROM
	package_item
WHERE
	package_id = @package_id
ORDER BY
	[name], type
	
RETURN 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqFindAllRoleTemplateDescriptions
	@role_template_id int
AS

SELECT
	role_template_id,
	language_id,
	description
	
FROM
	role_template_description
	
WHERE
	role_template_id = @role_template_id
	
RETURN 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqFindAllRoleTemplateMethods
	@role_template_id int,
	@language_id int
AS

SELECT
	rtm.role_template_id				AS RoleTemplateId,
	rtm.method_type_id					AS MethodTypeId,
	rtm.scope_id								AS ScopeId,
	mt.name											AS MethodTypeName,
	s.name											AS ScopeName,
	s.base											AS ScopeBase,
	dbo.iqGetShapesByScopeAsString(s.id)	AS ScopeShapesAsString
	
FROM
	role_template_method rtm,
	method_type mt,
	scope s
	
WHERE
	rtm.role_template_id = @role_template_id
AND
	mt.id = rtm.method_type_id
AND
	s.id = rtm.scope_id
	
ORDER BY
	mt.[name]
	
RETURN 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqFindAllRoleTemplateMethodsByRoleTemplate
	@role_template_id int
AS

SELECT
	role_template_id,
	method_type_id,
	scope_id
	
FROM
	role_template_method
	
WHERE
	role_template_id = @role_template_id

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqFindAllRoleTemplatesByService
	@service_id int
AS

SELECT
	id,
	[name],
	priority
	
FROM
	role_template rt
	
WHERE
	rt.service_id = @service_id

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqFindAllRolesBySubscription
	@subscription_id uniqueidentifier
AS

SELECT
	id,
	account_id,
	subscription_id,
	scope_id,
	role_template_id,
	active_from,
	active_to
	
FROM
	role r
	
WHERE
	r.subscription_id = @subscription_id

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqFindAllScopesByService
	@service_id int
AS

SELECT
	s.id,
	s.[name],
	s.base
	
FROM
	service_scope ss,
	scope s
	
WHERE
	ss.service_id = @service_id
AND
	ss.scope_id = s.id
	

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqFindAllScopesBySubscription
	@subscription_id uniqueidentifier
AS

SELECT
	s.id,
	s.[name],
	s.base
	
FROM
	subscription_scope ss,
	scope s
	
WHERE
	ss.subscription_id = @subscription_id
AND
	ss.scope_id = s.id
	
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqFindAllServiceChargesByServiceId (
	@service_id int
)

AS

SELECT 
	id, 
	service_id, 
	method_type_id, 
	schema_type,
	script,
	price,
	charge_unit_id 
	
FROM 
	service_charge
	
WHERE 
	service_id = @service_id


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqFindAllServicesByAuthorId (
	@author_id int,
	@language_id int
)

AS

SELECT 
	id, 
	author_id, 
	[name], 
	version, 
	xsd, 
	url_icon, 
	url_homepage, 
	state,
	role_map,
	sd.short_description		AS ServiceShortDescription
	
FROM 
	service se LEFT OUTER JOIN 
		service_description sd 
	ON
		se.id = sd.service_id
	AND
		sd.language_id = @language_id
	
WHERE 
	author_id = @author_id 

ORDER BY
	[name]

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqFindAllShapesByScope
	@scope_id int
AS

SELECT
	id			AS id,
	scope_id	AS scope_id,
	[select]	AS [select],
	type		AS type
	
FROM
	shape
	
WHERE
	scope_id = @scope_id
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqFindLatestPackage (
	@account_id int,
	@service_name nvarchar(64),
	@platform_id int
)

AS

SELECT TOP 1 
	p.id,
	p.service_id,
	p.platform_id,
	p.version,
	p.release_date,
	p.state

FROM
	package p,
	service s,
	subscription ss,
	account a
	
WHERE
	a.id = @account_id
AND
	s.name = @service_name
AND
	ss.service_id = s.id
AND
	ss.account_id = a.id
AND
	p.service_id = s.id
AND
	p.platform_id = @platform_id
AND
	p.state = 'A'
	
ORDER BY
	p.release_date DESC
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqFindServiceByAuthor (
	@id int,
	@author_id int,
	@language_id int
)

AS

SELECT
	id,
	author_id,
	[name],
	version,
	xsd,
	url_xsd,
	url_icon,
	url_homepage,
	state,
	role_map
	
FROM
	service
	
WHERE
	id = @id
AND
	author_id = @author_id
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqFindServiceByName (
	@name nvarchar(64),
	@language_id int
)

AS

SELECT
	id,
	author_id,
	[name],
	version,
	xsd,
	url_xsd,
	url_icon,
	url_homepage,
	state,
	role_map
	
FROM
	service
	
WHERE
	[name] = @name
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqFindSubscriptionByAccountService (
	@account_id int,
	@service_id int
)

AS

SELECT
	id,
	account_id,
	service_id,
	[xml],
	role_list,
	notify_list
	
FROM
	subscription
	
WHERE
	account_id = @account_id AND
	service_id = @service_id
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqListAllLanguages

AS

SELECT
	id				AS Id,
	[name]			AS Name
	
FROM
	language
	
ORDER BY
	[name]

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqListAllRoleTemplateMethods
	@role_template_id int,
	@language_id int
AS

SELECT
	rtm.role_template_id	AS RoleTemplateId,
	rtm.method_type_id		AS MethodTypeId,
	rtm.scope_id			AS ScopeId,
	mt.name					AS MethodTypeName,
	s.name					AS ScopeName,
	s.base					AS ScopeBase,
	dbo.iqGetShapesByScopeAsString(s.id)	AS ScopeShapesAsString
	
FROM
	role_template_method rtm,
	method_type mt,
	scope s
	
WHERE
	rtm.role_template_id = @role_template_id
AND
	mt.id = rtm.method_type_id
AND
	s.id = rtm.scope_id
	
ORDER BY
	mt.[name]
	
RETURN 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqListAllRoleTemplatesByService
	@service_id int,
	@language_id int
AS

SELECT
	rt.id				AS RoleTemplateId,
	rt.[name]			AS RoleTemplateName,
	rt.priority			AS RoleTemplatePriority,
	rtd.description		AS RoleTemplateDescriptionDescription,
	dbo.iqGetMethodsByRoleTemplateAsString(rt.id)	AS MethodsAsString
	
FROM
	role_template rt LEFT OUTER JOIN
		role_template_description rtd 
	ON
		rt.id = rtd.role_template_id
	AND
		rtd.language_id = @language_id
	
WHERE
	rt.service_id = @service_id
	
ORDER BY
	rt.[name]
	
RETURN 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--
-- Fetches list of scopes defined for a given service.
--
CREATE PROCEDURE dbo.iqListAllScopesByService
	@service_id int,
	@language_id int
AS

SELECT
	ss.service_id					AS ServiceId,
	s.id									AS ScopeId,
	s.[name]							AS ScopeName,
	s.base								AS ScopeBase,
	dbo.iqGetShapesByScopeAsString(s.id)	AS ShapesAsString
	
FROM
	service_scope ss,
	scope s
	
WHERE
	ss.service_id = @service_id
AND
	ss.scope_id = s.id
	
ORDER BY
	s.[name]
	
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqListAllScopesBySubscription
	@subscription_id uniqueidentifier,
	@language_id int
AS

SELECT
	ss.subscription_id	AS SubscriptionId,
	s.id				AS ScopeId,
	s.[name]			AS ScopeName,
	s.base				AS ScopeBase,
	dbo.iqGetShapesByScopeAsString(s.id)	AS ShapesAsString
	
FROM
	subscription_scope ss,
	scope s
	
WHERE
	ss.subscription_id = @subscription_id
AND
	ss.scope_id = s.id
	
ORDER BY
	s.[name]
	

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--
-- Returns union of scopes for service and subscription
--
CREATE PROCEDURE dbo.iqListAllScopesForSubscription
	@subscription_id uniqueidentifier,
	@language_id int
AS

SELECT
	subs.subscription_id	AS SubscriptionId,
	s.id					AS ScopeId,
	s.[name]				AS ScopeName,
	s.base					AS ScopeBase
	
FROM
	service_scope sers,
	scope s,
	subscription sub LEFT OUTER JOIN
		subscription_scope subs
	ON
		sub.id = subs.subscription_id
	
WHERE
	sers.scope_id = s.id
AND
	sers.service_id = sub.service_id
AND
	sub.id = @subscription_id
	
ORDER BY
	s.[name]
	

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqListAllServiceChargesByService
	@service_id int
AS

SELECT 
	sc.id						AS ServiceChargeId, 
	service_id			AS ServiceId, 
	method_type_id	AS MethodTypeId, 
	schema_type			AS SchemaType,
	script					AS Script,
	price						AS Price,
	charge_unit_id	AS ChargeUnitId,
	mt.name					AS MethodTypeName,
	cu.common_name	AS ChargeUnitCommonName 
	
FROM 
	service_charge sc,
	method_type mt,
	charge_unit cu
	
WHERE 
	service_id = @service_id
AND
	mt.id = method_type_id
AND
	cu.id = charge_unit_id


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqListListenersBySubscription
	@subscription_id uniqueidentifier,
	@language_id int
AS

SELECT
	a.iqid				AS Iqid,
	a.email				AS AccountEmail,
	sl.id			    AS SubscriptionListenerId,
	sl.filter			AS Filter,
	sl.context_uri	    AS ContextUri,
	sl.context			AS Context,
	sl.[to]				AS [To],
	sl.active_from	    AS ActiveFrom,
	sl.active_to		AS ActiveTo,
	sl.state			AS State
	
FROM
	account a,
	subscription s,
	subscription_listener sl
	
WHERE
	s.id = @subscription_id
AND
	sl.subscription_id = s.id
AND
	sl.account_id = a.id

ORDER BY
	Iqid, AccountEmail

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqListMySubscriptions (
	@account_id int,
	@language_id int
)

AS

SELECT
	su.id					AS SubscriptionId,
	su.service_id			AS ServiceId,
	se.name					AS ServiceName,
	se.version				AS ServiceVersion,
	se.url_icon				AS ServiceUrlIcon,
	sd.short_description	AS ServiceShortDescription,
	sd.long_description		AS ServiceLongDescription,
	a.name					AS AuthorName
	
FROM
	subscription su,
	service se LEFT OUTER JOIN 
		service_description sd 
	ON
		se.id = sd.service_id
	AND
		sd.language_id = @language_id,
	author a
	
WHERE
	su.account_id = @account_id
AND
	su.service_id = se.id
AND
	se.author_id = a.id
AND
	se.state = 'P'

ORDER BY
	ServiceName, ServiceVersion
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqListProvisionedServices
	@language_id int
AS

SELECT
	se.id					AS ServiceId,
	se.name					AS ServiceName,
	se.version				AS ServiceVersion,
	se.url_icon				AS ServiceUrlIcon,
	sd.short_description	AS ServiceShortDescription,
	sd.long_description		AS ServiceLongDescription,
	a.name					AS AuthorName
	
FROM
	service se LEFT OUTER JOIN 
		service_description sd 
	ON
		se.id = sd.service_id
	AND
		sd.language_id = @language_id,
	author a
	
WHERE
	se.author_id = a.id
AND
	se.state = 'P'

ORDER BY
	ServiceName, ServiceVersion, AuthorName
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--
-- Finds all roles associated with subscription
--
CREATE PROCEDURE dbo.iqListRolesBySubscription
	@subscription_id uniqueidentifier,
	@language_id int
AS

SELECT
	r.id				AS RoleId,
	r.subscription_id	AS SubscriptionId,
	r.account_id		AS AccountId,
	r.scope_id			AS ScopeId,
	r.role_template_id	AS RoleTemplateId,
	r.active_from		AS ActiveFrom,
	r.active_to			AS ActiveTo,
	rd.description		AS RoleDescription,
	rt.name				AS RoleTemplateName,
	rtd.description		AS RoleTemplateDescription,
	a.iqid				AS Iqid,
	a.email				AS AccountEmail
	
FROM
	account a,
	role r LEFT OUTER JOIN 
		role_description rd 
	ON
		r.id = rd.role_id
	AND
		rd.language_id = @language_id,
	role_template rt LEFT OUTER JOIN
		role_template_description rtd
	ON
		rt.id = rtd.role_template_id
	AND
		rtd.language_id = @language_id
	
WHERE
	r.subscription_id = @subscription_id
AND
	r.account_id = a.id
AND
	rt.id = r.role_template_id

ORDER BY
	Iqid, AccountEmail

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqListServiceScopes
	@service_id int,
	@language_id int
AS

SELECT
	s.id			AS Id,
	s.[name]		AS [Name]
	
FROM
	service_scope ss,
	scope s
	
WHERE
	ss.service_id = @service_id
AND
	ss.scope_id = s.id

ORDER BY
	s.[name]

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqLookupAuthor (
	@account_id int
)

AS

SELECT
	id,
	account_id,
	[name]
	
FROM
	author
	
WHERE
	account_id = @account_id

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqLookupRole (
	@account_id int,
	@subscription_id uniqueidentifier
)

AS

SELECT
	id,
	account_id,
	scope_id,
	role_template_id,
	active_from,
	active_to
	
FROM
	role r

WHERE
	r.subscription_id = @subscription_id
AND
	r.account_id = @account_id

-- TODO use active_from and active_to

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqLookupScopeByMethodTypeId (
	@role_template_id int,
	@method_type_id int
)

AS

SELECT
	s.id		AS id,
	s.[name]	AS [name],
	s.base		AS base

FROM
	scope s,
	role_template_method rtm

WHERE
	rtm.role_template_id = @role_template_id
AND
	rtm.method_type_id = @method_type_id
AND
	rtm.scope_id = s.id

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqReadAccount (
	@id int
)

AS

SELECT
	id,
	owner_account_id,
	group_id,
	iqid,
	email,
	password
	
FROM
	account
	
WHERE
	id = @id

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqReadMethodType (
	@id int
)

AS

SELECT
	id,
	[name]
	
FROM
	method_type
	
WHERE
	id = @id

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqReadPackage (
	@id int
)

AS

SELECT
	id,
	service_id,
	version,
	release_date,
	state
FROM
	package
WHERE
	id = @id

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqReadPackageItem (
	@id int,
	@author_id int
)

AS

SELECT
	[pi].id				AS id,
	[pi].package_id		AS package_id,
	[pi].[name]			AS [name],
	[pi].type			AS type,
	[pi].size			AS [size],
	[pi].data			AS data
	
FROM
	package_item [pi],
	package p,
	service s
	
WHERE
	[pi].id = @id
AND
	[pi].package_id = p.id
AND
	p.service_id = s.id
AND
	s.author_id = @author_id
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqReadRole (
	@id int
)

AS

SELECT
	id,
	account_id,
	role_template_id,
	scope_id,
	active_from,
	active_to
	
FROM
	role
	
WHERE
	id = @id

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqReadRoleTemplate (
	@id int
)

AS

SELECT
	id,
	[name],
	priority
	
FROM
	role_template
	
WHERE
	id = @id

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqReadRoleTemplateMethod (
	@role_template_id int,
	@method_type_id int,
	@language_id int
)

AS

SELECT
	role_template_id,
	method_type_id,
	scope_id
	
FROM
	role_template_method
	
WHERE
	role_template_id = @role_template_id
AND
	method_type_id = @method_type_id
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqReadScope (
	@id int
)

AS

SELECT
	id,
	language_id,
	[name],
	base
	
FROM
	scope
	
WHERE
	id = @id

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqReadService (
	@id int,
	@language_id int
)

AS

SELECT
	id,
	author_id,
	[name],
	version,
	xsd,
	url_xsd,
	url_icon,
	url_homepage,
	state,
	role_map
	
FROM
	service
	
WHERE
	id = @id
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqReadServiceCharge (
	@id int
)

AS

SELECT
	id,
	service_id,
	method_type_id,
	schema_type,
	script,
	price,
	charge_unit_id
	
FROM
	service_charge
	
WHERE
	id = @id
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqReadShape (
	@id int
)

AS

SELECT
	id,
	scope_id,
	[select],
	type
	
FROM
	shape
	
WHERE
	id = @id

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqReadSubscription (
	@id uniqueidentifier
)

AS

SELECT
	id,
	account_id,
	service_id,
	[xml],
	role_list,
	notify_list
	
FROM
	subscription
	
WHERE
	id = @id

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqReadSubscriptionListener (
	@id int
)

AS

SELECT
	id,
	account_id,
	subscription_id,
	filter,
	context,
	context_uri,
	active_from,
	active_to,
	[to],
	state
	
FROM
	subscription_listener
	
WHERE
	id = @id

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqServiceUpdate (
	@author_id int,
	@name nvarchar(64),
	@version nvarchar(16),
	@xsd text,
	@url_xsd nvarchar(160),
	@url_icon nvarchar(128),
	@url_homepage nvarchar(128),
	@state char(1),
	@Original_id int,
	@Original_author_id int,
	@Original_name nvarchar(64),
	@IsNull_version int,
	@Original_version nvarchar(16),
	@IsNull_url_xsd int,
	@Original_url_xsd nvarchar(160),
	@IsNull_url_icon int,
	@Original_url_icon nvarchar(128),
	@IsNull_url_homepage int,
	@Original_url_homepage nvarchar(128),
	@Original_state char(1)
)
AS

SET NOCOUNT OFF;

UPDATE
	[dbo].[service] 
	
SET
	[author_id] = @author_id, 
	[name] = @name,
	[version] = @version,
	[xsd] = @xsd,
	[url_xsd] = @url_xsd,
	[url_icon] = @url_icon,
	[url_homepage] = @url_homepage,
	[state] = @state

WHERE (
	([id] = @Original_id) 
	AND ([author_id] = @Original_author_id) 
	AND ([name] = @Original_name) 
	AND ((@IsNull_version = 1 AND [version] IS NULL) OR ([version] = @Original_version)) 
	AND ((@IsNull_url_xsd = 1 AND [url_xsd] IS NULL) OR ([url_xsd] = @Original_url_xsd)) 
	AND ((@IsNull_url_icon = 1 AND [url_icon] IS NULL) OR ([url_icon] = @Original_url_icon)) 
	AND ((@IsNull_url_homepage = 1 AND [url_homepage] IS NULL) OR ([url_homepage] = @Original_url_homepage)) 
	AND ([state] = @Original_state)
	)
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqSubscriptionServices (
	@account_id int,
	@language_id int
)

AS

SELECT 
	se.id, 
	se.author_id, 
	se.name, 
	se.version, 
	se.xsd, 
	se.url_icon, 
	se.url_homepage, 
	se.state,
	sd.short_description		AS ServiceShortDescription
	
FROM 
	subscription su,
	service se LEFT OUTER JOIN 
		service_description sd 
	ON
		se.id = sd.service_id
	AND
		sd.language_id = @language_id
	
WHERE 
	su.service_id = se.id
AND
	su.account_id = @account_id

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqUpdateAccount (
	@id int,
	@owner_account_id int,
	@group_id int,
	@iqid nvarchar(128),
	@email nvarchar(128),
	@password nvarchar(128)
)

AS

UPDATE
	account

SET
	owner_account_id = @owner_account_id,
	group_id = @group_id,
	iqid = @iqid,
	email = @email,
	password = @password

WHERE
	id = @id

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqUpdateRole (
	@id int,
	@account_id int,
	@role_template_id int,
	@scope_id int,
	@active_from datetime, 
	@active_to datetime
)

AS

UPDATE
	role

SET
	account_id = @account_id,
	role_template_id = @role_template_id,
	scope_id = @scope_id,
	active_from = @active_from, 
	active_to = @active_to

WHERE
	id = @id

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqUpdateRoleTemplate (
	@id int,
	@name nvarchar(64),
	@priority int
)

AS

UPDATE
	role_template

SET
	[name] = @name,
	priority = @priority

WHERE
	id = @id

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqUpdateRoleTemplateDescription (
	@role_template_id int,
	@language_id int,
	@description text
)

AS

UPDATE
	role_template_description

SET
	description = @description

WHERE
	role_template_id = @role_template_id 
AND
	language_id = @language_id

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqUpdateRoleTemplateMethod (
	@role_template_id int,
	@method_type_id int,
	@scope_id int
)

AS

UPDATE
	role_template_method

SET
	scope_id = @scope_id

WHERE
	role_template_id = @role_template_id
AND
	method_type_id = @method_type_id
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqUpdateScope (
	@id int,
	@language_id int,
	@name nvarchar(128),
	@base nvarchar(3)
)

AS

UPDATE
	scope

SET
	[name] = @name,
	base = @base

WHERE
	id = @id
AND
    language_id = @language_id
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqUpdateService (
	@id int,
	@author_id int,
	@name nvarchar(64),
	@version nvarchar(16),
	@xsd text,
	@url_xsd nvarchar(320),
	@url_icon nvarchar(128),
	@url_homepage nvarchar(128),
	@state char(1),
	@role_map text
)

AS

UPDATE
	service

SET
	author_id = @author_id,
	[name] = @name,
	version = @version,
	xsd = @xsd,
	url_xsd = @url_xsd,
	url_icon = @url_icon,
	url_homepage = @url_homepage,
	state = @state,
	role_map = @role_map

WHERE
	id = @id

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqUpdateServiceCharge (
	@id int,
	@service_id int,
	@method_type_id int,
	@schema_type nvarchar(64),
	@script text = NULL,
	@price float,
	@charge_unit_id int
)

AS

UPDATE
	service_charge

SET
	service_id = @service_id,
	method_type_id = @method_type_id,
	schema_type = @schema_type,
	script = @script,
	price = @price,
	charge_unit_id = @charge_unit_id

WHERE
	id = @id
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqUpdateShape (
	@id int,
	@scope_id int,
	@select nvarchar(128),
	@type char(1)
)

AS

UPDATE
	shape

SET
	scope_id = @scope_id,
	[select] = @select,
	type = @type

WHERE
	id = @id

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqUpdateSubscription (
	@service_id int,
	@account_id int,
	@xml text,
	@role_list text,
	@notify_list text
)

AS

UPDATE
	subscription

SET
	[xml] = @xml,
	role_list = @role_list,
	notify_list = @notify_list

WHERE
	service_id = @service_id
AND
	account_id = @account_id
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.iqUpdateSubscriptionListener (
	@id int,
	@account_id int,
	@subscription_id uniqueidentifier,
	@filter nvarchar(128),
	@context text,
	@context_uri nvarchar(128),
	@to nvarchar(128),
	@active_from datetime, 
	@active_to datetime,
	@state char(1)
)

AS

UPDATE
	subscription_listener

SET
	account_id = @account_id,
	subscription_id = @subscription_id,
	filter = @filter,
	context = @context,
	context_uri = @context_uri,
	[to] = @to,
	active_from = @active_from,
	active_to = @active_to,
	state = @state

WHERE
	id = @id
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE FUNCTION dbo.iqGetMethodsByRoleTemplateAsString (
	@role_template_id int
)

RETURNS nvarchar(2048)

AS 
	
BEGIN

	DECLARE @output nvarchar(2048), @name nvarchar(64)
	
	DECLARE csr CURSOR FOR
		SELECT
			mt.name
		FROM
			role_template_method rtm,
			method_type mt
		WHERE
			rtm.role_template_id = @role_template_id
		AND
			mt.id = rtm.method_type_id
		ORDER BY
			mt.name
		
	OPEN csr
	
	FETCH NEXT FROM csr INTO @name
	
	SET @output = ''

	-- Check @@FETCH_STATUS to see if there are any more rows to fetch.
	WHILE (@@FETCH_STATUS = 0) BEGIN
		
		SET @output = @output + '<span class="rtm">' + @name + '</span>' + ', '
		
		-- This is executed as long as the previous fetch succeeds.
		FETCH NEXT FROM csr INTO @name
	END

	CLOSE csr
	DEALLOCATE csr		
	
	IF (LEN(@output) > 2) BEGIN
		SET @output = LEFT(@output, LEN(@output) - 1)
	END
	
	IF (LEN(@output) = 0) BEGIN
		SET @output = '-'
	END
	
	RETURN @output

END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE FUNCTION dbo.iqGetShapesByScopeAsString (
	@scope_id int
)

RETURNS nvarchar(2048)

AS 
	
BEGIN

	DECLARE @output nvarchar(2048), @select nvarchar(128), @type nchar(1)
	
	DECLARE csr CURSOR FOR
		SELECT
			[select],
			type
		FROM
			shape
		WHERE
			scope_id = @scope_id
		
	OPEN csr
	
	FETCH NEXT FROM csr INTO @select, @type
	
	SET @output = '' 

	-- Check @@FETCH_STATUS to see if there are any more rows to fetch.
	WHILE (@@FETCH_STATUS = 0) BEGIN
		
		IF (@type = 'I') BEGIN
			SET @output = @output + '<span class="include">' + @select + '</span>'
		END
		
		IF (@type = 'E') BEGIN
			SET @output = @output + '<span class="exclude">' + @select + '</span>'
		END
		
		SET @output = @output + ', '
		
		-- This is executed as long as the previous fetch succeeds.
		FETCH NEXT FROM csr INTO @select, @type
	END

	CLOSE csr
	DEALLOCATE csr
	
	IF (LEN(@output) > 2) BEGIN
		SET @output = LEFT(@output, LEN(@output) - 1)
	END
	
	IF (LEN(@output) = 0) BEGIN
		SET @output = '-'
	END
	
	RETURN @output

END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

