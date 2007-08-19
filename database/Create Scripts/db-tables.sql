IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_account_account]') AND parent_object_id = OBJECT_ID(N'[dbo].[account]'))
ALTER TABLE [dbo].[account] DROP CONSTRAINT [FK_account_account]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_account_group]') AND parent_object_id = OBJECT_ID(N'[dbo].[account]'))
ALTER TABLE [dbo].[account] DROP CONSTRAINT [FK_account_group]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_subscription_scope_scope]') AND parent_object_id = OBJECT_ID(N'[dbo].[subscription_scope]'))
ALTER TABLE [dbo].[subscription_scope] DROP CONSTRAINT [FK_subscription_scope_scope]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_administrator_account]') AND parent_object_id = OBJECT_ID(N'[dbo].[administrator]'))
ALTER TABLE [dbo].[administrator] DROP CONSTRAINT [FK_administrator_account]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__aspnet_Me__Appli__6EE06CCD]') AND parent_object_id = OBJECT_ID(N'[dbo].[aspnet_Membership]'))
ALTER TABLE [dbo].[aspnet_Membership] DROP CONSTRAINT [FK__aspnet_Me__Appli__6EE06CCD]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__aspnet_Me__UserI__6FD49106]') AND parent_object_id = OBJECT_ID(N'[dbo].[aspnet_Membership]'))
ALTER TABLE [dbo].[aspnet_Membership] DROP CONSTRAINT [FK__aspnet_Me__UserI__6FD49106]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__aspnet_Pa__Appli__2077C861]') AND parent_object_id = OBJECT_ID(N'[dbo].[aspnet_Paths]'))
ALTER TABLE [dbo].[aspnet_Paths] DROP CONSTRAINT [FK__aspnet_Pa__Appli__2077C861]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__aspnet_Pe__PathI__2630A1B7]') AND parent_object_id = OBJECT_ID(N'[dbo].[aspnet_PersonalizationAllUsers]'))
ALTER TABLE [dbo].[aspnet_PersonalizationAllUsers] DROP CONSTRAINT [FK__aspnet_Pe__PathI__2630A1B7]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__aspnet_Pe__PathI__2A01329B]') AND parent_object_id = OBJECT_ID(N'[dbo].[aspnet_PersonalizationPerUser]'))
ALTER TABLE [dbo].[aspnet_PersonalizationPerUser] DROP CONSTRAINT [FK__aspnet_Pe__PathI__2A01329B]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__aspnet_Pe__UserI__2AF556D4]') AND parent_object_id = OBJECT_ID(N'[dbo].[aspnet_PersonalizationPerUser]'))
ALTER TABLE [dbo].[aspnet_PersonalizationPerUser] DROP CONSTRAINT [FK__aspnet_Pe__UserI__2AF556D4]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__aspnet_Pr__UserI__03DB89B3]') AND parent_object_id = OBJECT_ID(N'[dbo].[aspnet_Profile]'))
ALTER TABLE [dbo].[aspnet_Profile] DROP CONSTRAINT [FK__aspnet_Pr__UserI__03DB89B3]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__aspnet_Ro__Appli__0D64F3ED]') AND parent_object_id = OBJECT_ID(N'[dbo].[aspnet_Roles]'))
ALTER TABLE [dbo].[aspnet_Roles] DROP CONSTRAINT [FK__aspnet_Ro__Appli__0D64F3ED]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__aspnet_Us__Appli__5EAA0504]') AND parent_object_id = OBJECT_ID(N'[dbo].[aspnet_Users]'))
ALTER TABLE [dbo].[aspnet_Users] DROP CONSTRAINT [FK__aspnet_Us__Appli__5EAA0504]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__aspnet_Us__RoleI__1229A90A]') AND parent_object_id = OBJECT_ID(N'[dbo].[aspnet_UsersInRoles]'))
ALTER TABLE [dbo].[aspnet_UsersInRoles] DROP CONSTRAINT [FK__aspnet_Us__RoleI__1229A90A]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__aspnet_Us__UserI__113584D1]') AND parent_object_id = OBJECT_ID(N'[dbo].[aspnet_UsersInRoles]'))
ALTER TABLE [dbo].[aspnet_UsersInRoles] DROP CONSTRAINT [FK__aspnet_Us__UserI__113584D1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_author_account]') AND parent_object_id = OBJECT_ID(N'[dbo].[author]'))
ALTER TABLE [dbo].[author] DROP CONSTRAINT [FK_author_account]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_charge_unit_description_charge_unit]') AND parent_object_id = OBJECT_ID(N'[dbo].[charge_unit_description]'))
ALTER TABLE [dbo].[charge_unit_description] DROP CONSTRAINT [FK_charge_unit_description_charge_unit]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_charge_unit_description_language]') AND parent_object_id = OBJECT_ID(N'[dbo].[charge_unit_description]'))
ALTER TABLE [dbo].[charge_unit_description] DROP CONSTRAINT [FK_charge_unit_description_language]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_delete_log_subscription]') AND parent_object_id = OBJECT_ID(N'[dbo].[delete_log]'))
ALTER TABLE [dbo].[delete_log] DROP CONSTRAINT [FK_delete_log_subscription]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_group_administrator_administrator]') AND parent_object_id = OBJECT_ID(N'[dbo].[group_administrator]'))
ALTER TABLE [dbo].[group_administrator] DROP CONSTRAINT [FK_group_administrator_administrator]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_group_administrator_group]') AND parent_object_id = OBJECT_ID(N'[dbo].[group_administrator]'))
ALTER TABLE [dbo].[group_administrator] DROP CONSTRAINT [FK_group_administrator_group]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_method_method_type]') AND parent_object_id = OBJECT_ID(N'[dbo].[method]'))
ALTER TABLE [dbo].[method] DROP CONSTRAINT [FK_method_method_type]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_package_platform]') AND parent_object_id = OBJECT_ID(N'[dbo].[package]'))
ALTER TABLE [dbo].[package] DROP CONSTRAINT [FK_package_platform]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_package_service]') AND parent_object_id = OBJECT_ID(N'[dbo].[package]'))
ALTER TABLE [dbo].[package] DROP CONSTRAINT [FK_package_service]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_package_item_package]') AND parent_object_id = OBJECT_ID(N'[dbo].[package_item]'))
ALTER TABLE [dbo].[package_item] DROP CONSTRAINT [FK_package_item_package]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_platform_language]') AND parent_object_id = OBJECT_ID(N'[dbo].[platform]'))
ALTER TABLE [dbo].[platform] DROP CONSTRAINT [FK_platform_language]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_role_account]') AND parent_object_id = OBJECT_ID(N'[dbo].[role]'))
ALTER TABLE [dbo].[role] DROP CONSTRAINT [FK_role_account]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_role_role_template]') AND parent_object_id = OBJECT_ID(N'[dbo].[role]'))
ALTER TABLE [dbo].[role] DROP CONSTRAINT [FK_role_role_template]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_role_scope]') AND parent_object_id = OBJECT_ID(N'[dbo].[role]'))
ALTER TABLE [dbo].[role] DROP CONSTRAINT [FK_role_scope]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_control_description_language]') AND parent_object_id = OBJECT_ID(N'[dbo].[role_description]'))
ALTER TABLE [dbo].[role_description] DROP CONSTRAINT [FK_control_description_language]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_role_description_role]') AND parent_object_id = OBJECT_ID(N'[dbo].[role_description]'))
ALTER TABLE [dbo].[role_description] DROP CONSTRAINT [FK_role_description_role]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_role_template_service]') AND parent_object_id = OBJECT_ID(N'[dbo].[role_template]'))
ALTER TABLE [dbo].[role_template] DROP CONSTRAINT [FK_role_template_service]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_access_control_description_language]') AND parent_object_id = OBJECT_ID(N'[dbo].[role_template_description]'))
ALTER TABLE [dbo].[role_template_description] DROP CONSTRAINT [FK_access_control_description_language]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_role_template_role_template_description]') AND parent_object_id = OBJECT_ID(N'[dbo].[role_template_description]'))
ALTER TABLE [dbo].[role_template_description] DROP CONSTRAINT [FK_role_template_role_template_description]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_access_control_action_scope]') AND parent_object_id = OBJECT_ID(N'[dbo].[role_template_method]'))
ALTER TABLE [dbo].[role_template_method] DROP CONSTRAINT [FK_access_control_action_scope]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_role_template_method_method_type]') AND parent_object_id = OBJECT_ID(N'[dbo].[role_template_method]'))
ALTER TABLE [dbo].[role_template_method] DROP CONSTRAINT [FK_role_template_method_method_type]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_role_template_method_role_template]') AND parent_object_id = OBJECT_ID(N'[dbo].[role_template_method]'))
ALTER TABLE [dbo].[role_template_method] DROP CONSTRAINT [FK_role_template_method_role_template]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_service_author]') AND parent_object_id = OBJECT_ID(N'[dbo].[service]'))
ALTER TABLE [dbo].[service] DROP CONSTRAINT [FK_service_author]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_service_charge_charge_unit]') AND parent_object_id = OBJECT_ID(N'[dbo].[service_charge]'))
ALTER TABLE [dbo].[service_charge] DROP CONSTRAINT [FK_service_charge_charge_unit]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_service_charge_service]') AND parent_object_id = OBJECT_ID(N'[dbo].[service_charge]'))
ALTER TABLE [dbo].[service_charge] DROP CONSTRAINT [FK_service_charge_service]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_service_dependency_service]') AND parent_object_id = OBJECT_ID(N'[dbo].[service_dependency]'))
ALTER TABLE [dbo].[service_dependency] DROP CONSTRAINT [FK_service_dependency_service]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_service_dependency_service1]') AND parent_object_id = OBJECT_ID(N'[dbo].[service_dependency]'))
ALTER TABLE [dbo].[service_dependency] DROP CONSTRAINT [FK_service_dependency_service1]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_service_description_language]') AND parent_object_id = OBJECT_ID(N'[dbo].[service_description]'))
ALTER TABLE [dbo].[service_description] DROP CONSTRAINT [FK_service_description_language]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_service_description_service]') AND parent_object_id = OBJECT_ID(N'[dbo].[service_description]'))
ALTER TABLE [dbo].[service_description] DROP CONSTRAINT [FK_service_description_service]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_service_method_method]') AND parent_object_id = OBJECT_ID(N'[dbo].[service_method]'))
ALTER TABLE [dbo].[service_method] DROP CONSTRAINT [FK_service_method_method]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_service_method_service]') AND parent_object_id = OBJECT_ID(N'[dbo].[service_method]'))
ALTER TABLE [dbo].[service_method] DROP CONSTRAINT [FK_service_method_service]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_service_scope_scope]') AND parent_object_id = OBJECT_ID(N'[dbo].[service_scope]'))
ALTER TABLE [dbo].[service_scope] DROP CONSTRAINT [FK_service_scope_scope]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_service_scope_service]') AND parent_object_id = OBJECT_ID(N'[dbo].[service_scope]'))
ALTER TABLE [dbo].[service_scope] DROP CONSTRAINT [FK_service_scope_service]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_shape_scope]') AND parent_object_id = OBJECT_ID(N'[dbo].[shape]'))
ALTER TABLE [dbo].[shape] DROP CONSTRAINT [FK_shape_scope]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_subscription_account]') AND parent_object_id = OBJECT_ID(N'[dbo].[subscription]'))
ALTER TABLE [dbo].[subscription] DROP CONSTRAINT [FK_subscription_account]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_subscription_service]') AND parent_object_id = OBJECT_ID(N'[dbo].[subscription]'))
ALTER TABLE [dbo].[subscription] DROP CONSTRAINT [FK_subscription_service]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_subscription_charge_service_charge]') AND parent_object_id = OBJECT_ID(N'[dbo].[subscription_charge]'))
ALTER TABLE [dbo].[subscription_charge] DROP CONSTRAINT [FK_subscription_charge_service_charge]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_subscription_listener_account]') AND parent_object_id = OBJECT_ID(N'[dbo].[subscription_listener]'))
ALTER TABLE [dbo].[subscription_listener] DROP CONSTRAINT [FK_subscription_listener_account]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_subscription_listener_subscription]') AND parent_object_id = OBJECT_ID(N'[dbo].[subscription_listener]'))
ALTER TABLE [dbo].[subscription_listener] DROP CONSTRAINT [FK_subscription_listener_subscription]
GO
/****** Object:  Table [dbo].[account]    Script Date: 01/25/2007 22:18:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[account]') AND type in (N'U'))
DROP TABLE [dbo].[account]
GO
/****** Object:  Table [dbo].[subscription_scope]    Script Date: 01/25/2007 22:18:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[subscription_scope]') AND type in (N'U'))
DROP TABLE [dbo].[subscription_scope]
GO
/****** Object:  Table [dbo].[activity]    Script Date: 01/25/2007 22:18:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[activity]') AND type in (N'U'))
DROP TABLE [dbo].[activity]
GO
/****** Object:  Table [dbo].[administrator]    Script Date: 01/25/2007 22:18:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[administrator]') AND type in (N'U'))
DROP TABLE [dbo].[administrator]
GO
/****** Object:  Table [dbo].[aspnet_Applications]    Script Date: 01/25/2007 22:18:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Applications]') AND type in (N'U'))
DROP TABLE [dbo].[aspnet_Applications]
GO
/****** Object:  Table [dbo].[aspnet_Membership]    Script Date: 01/25/2007 22:18:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Membership]') AND type in (N'U'))
DROP TABLE [dbo].[aspnet_Membership]
GO
/****** Object:  Table [dbo].[aspnet_Paths]    Script Date: 01/25/2007 22:18:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Paths]') AND type in (N'U'))
DROP TABLE [dbo].[aspnet_Paths]
GO
/****** Object:  Table [dbo].[aspnet_PersonalizationAllUsers]    Script Date: 01/25/2007 22:18:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_PersonalizationAllUsers]') AND type in (N'U'))
DROP TABLE [dbo].[aspnet_PersonalizationAllUsers]
GO
/****** Object:  Table [dbo].[aspnet_PersonalizationPerUser]    Script Date: 01/25/2007 22:18:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_PersonalizationPerUser]') AND type in (N'U'))
DROP TABLE [dbo].[aspnet_PersonalizationPerUser]
GO
/****** Object:  Table [dbo].[aspnet_Profile]    Script Date: 01/25/2007 22:18:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Profile]') AND type in (N'U'))
DROP TABLE [dbo].[aspnet_Profile]
GO
/****** Object:  Table [dbo].[aspnet_Roles]    Script Date: 01/25/2007 22:18:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Roles]') AND type in (N'U'))
DROP TABLE [dbo].[aspnet_Roles]
GO
/****** Object:  Table [dbo].[aspnet_SchemaVersions]    Script Date: 01/25/2007 22:18:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_SchemaVersions]') AND type in (N'U'))
DROP TABLE [dbo].[aspnet_SchemaVersions]
GO
/****** Object:  Table [dbo].[aspnet_Users]    Script Date: 01/25/2007 22:18:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Users]') AND type in (N'U'))
DROP TABLE [dbo].[aspnet_Users]
GO
/****** Object:  Table [dbo].[aspnet_UsersInRoles]    Script Date: 01/25/2007 22:18:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_UsersInRoles]') AND type in (N'U'))
DROP TABLE [dbo].[aspnet_UsersInRoles]
GO
/****** Object:  Table [dbo].[aspnet_WebEvent_Events]    Script Date: 01/25/2007 22:18:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_WebEvent_Events]') AND type in (N'U'))
DROP TABLE [dbo].[aspnet_WebEvent_Events]
GO
/****** Object:  Table [dbo].[author]    Script Date: 01/25/2007 22:18:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[author]') AND type in (N'U'))
DROP TABLE [dbo].[author]
GO
/****** Object:  Table [dbo].[charge_unit]    Script Date: 01/25/2007 22:18:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[charge_unit]') AND type in (N'U'))
DROP TABLE [dbo].[charge_unit]
GO
/****** Object:  Table [dbo].[charge_unit_description]    Script Date: 01/25/2007 22:18:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[charge_unit_description]') AND type in (N'U'))
DROP TABLE [dbo].[charge_unit_description]
GO
/****** Object:  Table [dbo].[delete_log]    Script Date: 01/25/2007 22:18:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[delete_log]') AND type in (N'U'))
DROP TABLE [dbo].[delete_log]
GO
/****** Object:  Table [dbo].[group]    Script Date: 01/25/2007 22:18:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[group]') AND type in (N'U'))
DROP TABLE [dbo].[group]
GO
/****** Object:  Table [dbo].[group_administrator]    Script Date: 01/25/2007 22:18:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[group_administrator]') AND type in (N'U'))
DROP TABLE [dbo].[group_administrator]
GO
/****** Object:  Table [dbo].[history]    Script Date: 01/25/2007 22:18:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[history]') AND type in (N'U'))
DROP TABLE [dbo].[history]
GO
/****** Object:  Table [dbo].[language]    Script Date: 01/25/2007 22:18:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[language]') AND type in (N'U'))
DROP TABLE [dbo].[language]
GO
/****** Object:  Table [dbo].[method]    Script Date: 01/25/2007 22:18:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[method]') AND type in (N'U'))
DROP TABLE [dbo].[method]
GO
/****** Object:  Table [dbo].[method_history]    Script Date: 01/25/2007 22:18:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[method_history]') AND type in (N'U'))
DROP TABLE [dbo].[method_history]
GO
/****** Object:  Table [dbo].[method_type]    Script Date: 01/25/2007 22:18:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[method_type]') AND type in (N'U'))
DROP TABLE [dbo].[method_type]
GO
/****** Object:  Table [dbo].[package]    Script Date: 01/25/2007 22:18:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[package]') AND type in (N'U'))
DROP TABLE [dbo].[package]
GO
/****** Object:  Table [dbo].[package_item]    Script Date: 01/25/2007 22:18:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[package_item]') AND type in (N'U'))
DROP TABLE [dbo].[package_item]
GO
/****** Object:  Table [dbo].[platform]    Script Date: 01/25/2007 22:18:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[platform]') AND type in (N'U'))
DROP TABLE [dbo].[platform]
GO
/****** Object:  Table [dbo].[role]    Script Date: 01/25/2007 22:18:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[role]') AND type in (N'U'))
DROP TABLE [dbo].[role]
GO
/****** Object:  Table [dbo].[role_description]    Script Date: 01/25/2007 22:18:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[role_description]') AND type in (N'U'))
DROP TABLE [dbo].[role_description]
GO
/****** Object:  Table [dbo].[role_template]    Script Date: 01/25/2007 22:18:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[role_template]') AND type in (N'U'))
DROP TABLE [dbo].[role_template]
GO
/****** Object:  Table [dbo].[role_template_description]    Script Date: 01/25/2007 22:18:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[role_template_description]') AND type in (N'U'))
DROP TABLE [dbo].[role_template_description]
GO
/****** Object:  Table [dbo].[role_template_method]    Script Date: 01/25/2007 22:18:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[role_template_method]') AND type in (N'U'))
DROP TABLE [dbo].[role_template_method]
GO
/****** Object:  Table [dbo].[scope]    Script Date: 01/25/2007 22:18:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[scope]') AND type in (N'U'))
DROP TABLE [dbo].[scope]
GO
/****** Object:  Table [dbo].[service]    Script Date: 01/25/2007 22:18:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[service]') AND type in (N'U'))
DROP TABLE [dbo].[service]
GO
/****** Object:  Table [dbo].[service_charge]    Script Date: 01/25/2007 22:18:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[service_charge]') AND type in (N'U'))
DROP TABLE [dbo].[service_charge]
GO
/****** Object:  Table [dbo].[service_dependency]    Script Date: 01/25/2007 22:18:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[service_dependency]') AND type in (N'U'))
DROP TABLE [dbo].[service_dependency]
GO
/****** Object:  Table [dbo].[service_description]    Script Date: 01/25/2007 22:18:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[service_description]') AND type in (N'U'))
DROP TABLE [dbo].[service_description]
GO
/****** Object:  Table [dbo].[service_method]    Script Date: 01/25/2007 22:18:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[service_method]') AND type in (N'U'))
DROP TABLE [dbo].[service_method]
GO
/****** Object:  Table [dbo].[service_scope]    Script Date: 01/25/2007 22:18:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[service_scope]') AND type in (N'U'))
DROP TABLE [dbo].[service_scope]
GO
/****** Object:  Table [dbo].[shape]    Script Date: 01/25/2007 22:18:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[shape]') AND type in (N'U'))
DROP TABLE [dbo].[shape]
GO
/****** Object:  Table [dbo].[subscription]    Script Date: 01/25/2007 22:18:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[subscription]') AND type in (N'U'))
DROP TABLE [dbo].[subscription]
GO
/****** Object:  Table [dbo].[subscription_charge]    Script Date: 01/25/2007 22:18:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[subscription_charge]') AND type in (N'U'))
DROP TABLE [dbo].[subscription_charge]
GO
/****** Object:  Table [dbo].[subscription_listener]    Script Date: 01/25/2007 22:18:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[subscription_listener]') AND type in (N'U'))
DROP TABLE [dbo].[subscription_listener]
GO
/****** Object:  Table [dbo].[account]    Script Date: 01/25/2007 22:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[account]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[account](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[owner_account_id] [int] NULL,
	[group_id] [int] NULL,
	[iqid] [nvarchar](128) NOT NULL,
	[email] [nvarchar](128) NOT NULL,
	[password] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_account] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [IX_account] UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [IX_iqid] UNIQUE NONCLUSTERED 
(
	[iqid] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[subscription_scope]    Script Date: 01/25/2007 22:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[subscription_scope]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[subscription_scope](
	[subscription_id] [uniqueidentifier] NOT NULL,
	[scope_id] [int] NOT NULL,
 CONSTRAINT [PK_subscription_scope] PRIMARY KEY CLUSTERED 
(
	[subscription_id] ASC,
	[scope_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[activity]    Script Date: 01/25/2007 22:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[activity]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[activity](
	[subscription_id] [int] NOT NULL,
	[timestamp] [datetime] NOT NULL,
	[client_ip] [nvarchar](32) NOT NULL,
	[action] [char](1) NOT NULL,
	[agent_type] [nvarchar](32) NOT NULL
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[administrator]    Script Date: 01/25/2007 22:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[administrator]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[administrator](
	[id] [int] NOT NULL,
	[account_id] [int] NOT NULL,
 CONSTRAINT [PK_administrator] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[aspnet_Applications]    Script Date: 01/25/2007 22:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Applications]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[aspnet_Applications](
	[ApplicationName] [nvarchar](256) NOT NULL,
	[LoweredApplicationName] [nvarchar](256) NOT NULL,
	[ApplicationId] [uniqueidentifier] NOT NULL DEFAULT (newid()),
	[Description] [nvarchar](256) NULL,
PRIMARY KEY NONCLUSTERED 
(
	[ApplicationId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[LoweredApplicationName] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[ApplicationName] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO

/****** Object:  Index [aspnet_Applications_Index]    Script Date: 01/25/2007 22:18:26 ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Applications]') AND name = N'aspnet_Applications_Index')
CREATE CLUSTERED INDEX [aspnet_Applications_Index] ON [dbo].[aspnet_Applications] 
(
	[LoweredApplicationName] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[aspnet_Membership]    Script Date: 01/25/2007 22:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Membership]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[aspnet_Membership](
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[Password] [nvarchar](128) NOT NULL,
	[PasswordFormat] [int] NOT NULL DEFAULT ((0)),
	[PasswordSalt] [nvarchar](128) NOT NULL,
	[MobilePIN] [nvarchar](16) NULL,
	[Email] [nvarchar](256) NULL,
	[LoweredEmail] [nvarchar](256) NULL,
	[PasswordQuestion] [nvarchar](256) NULL,
	[PasswordAnswer] [nvarchar](128) NULL,
	[IsApproved] [bit] NOT NULL,
	[IsLockedOut] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[LastLoginDate] [datetime] NOT NULL,
	[LastPasswordChangedDate] [datetime] NOT NULL,
	[LastLockoutDate] [datetime] NOT NULL,
	[FailedPasswordAttemptCount] [int] NOT NULL,
	[FailedPasswordAttemptWindowStart] [datetime] NOT NULL,
	[FailedPasswordAnswerAttemptCount] [int] NOT NULL,
	[FailedPasswordAnswerAttemptWindowStart] [datetime] NOT NULL,
	[Comment] [ntext] NULL,
PRIMARY KEY NONCLUSTERED 
(
	[UserId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO

/****** Object:  Index [aspnet_Membership_index]    Script Date: 01/25/2007 22:18:26 ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Membership]') AND name = N'aspnet_Membership_index')
CREATE CLUSTERED INDEX [aspnet_Membership_index] ON [dbo].[aspnet_Membership] 
(
	[ApplicationId] ASC,
	[LoweredEmail] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[aspnet_Paths]    Script Date: 01/25/2007 22:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Paths]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[aspnet_Paths](
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[PathId] [uniqueidentifier] NOT NULL DEFAULT (newid()),
	[Path] [nvarchar](256) NOT NULL,
	[LoweredPath] [nvarchar](256) NOT NULL,
PRIMARY KEY NONCLUSTERED 
(
	[PathId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO

/****** Object:  Index [aspnet_Paths_index]    Script Date: 01/25/2007 22:18:26 ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Paths]') AND name = N'aspnet_Paths_index')
CREATE UNIQUE CLUSTERED INDEX [aspnet_Paths_index] ON [dbo].[aspnet_Paths] 
(
	[ApplicationId] ASC,
	[LoweredPath] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[aspnet_PersonalizationAllUsers]    Script Date: 01/25/2007 22:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_PersonalizationAllUsers]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[aspnet_PersonalizationAllUsers](
	[PathId] [uniqueidentifier] NOT NULL,
	[PageSettings] [image] NOT NULL,
	[LastUpdatedDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PathId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[aspnet_PersonalizationPerUser]    Script Date: 01/25/2007 22:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_PersonalizationPerUser]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[aspnet_PersonalizationPerUser](
	[Id] [uniqueidentifier] NOT NULL DEFAULT (newid()),
	[PathId] [uniqueidentifier] NULL,
	[UserId] [uniqueidentifier] NULL,
	[PageSettings] [image] NOT NULL,
	[LastUpdatedDate] [datetime] NOT NULL,
PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO

/****** Object:  Index [aspnet_PersonalizationPerUser_index1]    Script Date: 01/25/2007 22:18:26 ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_PersonalizationPerUser]') AND name = N'aspnet_PersonalizationPerUser_index1')
CREATE UNIQUE CLUSTERED INDEX [aspnet_PersonalizationPerUser_index1] ON [dbo].[aspnet_PersonalizationPerUser] 
(
	[PathId] ASC,
	[UserId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
GO

/****** Object:  Index [aspnet_PersonalizationPerUser_ncindex2]    Script Date: 01/25/2007 22:18:26 ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_PersonalizationPerUser]') AND name = N'aspnet_PersonalizationPerUser_ncindex2')
CREATE UNIQUE NONCLUSTERED INDEX [aspnet_PersonalizationPerUser_ncindex2] ON [dbo].[aspnet_PersonalizationPerUser] 
(
	[UserId] ASC,
	[PathId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[aspnet_Profile]    Script Date: 01/25/2007 22:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Profile]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[aspnet_Profile](
	[UserId] [uniqueidentifier] NOT NULL,
	[PropertyNames] [ntext] NOT NULL,
	[PropertyValuesString] [ntext] NOT NULL,
	[PropertyValuesBinary] [image] NOT NULL,
	[LastUpdatedDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[aspnet_Roles]    Script Date: 01/25/2007 22:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Roles]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[aspnet_Roles](
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL DEFAULT (newid()),
	[RoleName] [nvarchar](256) NOT NULL,
	[LoweredRoleName] [nvarchar](256) NOT NULL,
	[Description] [nvarchar](256) NULL,
PRIMARY KEY NONCLUSTERED 
(
	[RoleId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO

/****** Object:  Index [aspnet_Roles_index1]    Script Date: 01/25/2007 22:18:26 ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Roles]') AND name = N'aspnet_Roles_index1')
CREATE UNIQUE CLUSTERED INDEX [aspnet_Roles_index1] ON [dbo].[aspnet_Roles] 
(
	[ApplicationId] ASC,
	[LoweredRoleName] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[aspnet_SchemaVersions]    Script Date: 01/25/2007 22:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_SchemaVersions]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[aspnet_SchemaVersions](
	[Feature] [nvarchar](128) NOT NULL,
	[CompatibleSchemaVersion] [nvarchar](128) NOT NULL,
	[IsCurrentVersion] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Feature] ASC,
	[CompatibleSchemaVersion] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[aspnet_Users]    Script Date: 01/25/2007 22:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Users]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[aspnet_Users](
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL DEFAULT (newid()),
	[UserName] [nvarchar](256) NOT NULL,
	[LoweredUserName] [nvarchar](256) NOT NULL,
	[MobileAlias] [nvarchar](16) NULL DEFAULT (NULL),
	[IsAnonymous] [bit] NOT NULL DEFAULT ((0)),
	[LastActivityDate] [datetime] NOT NULL,
PRIMARY KEY NONCLUSTERED 
(
	[UserId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO

/****** Object:  Index [aspnet_Users_Index]    Script Date: 01/25/2007 22:18:26 ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Users]') AND name = N'aspnet_Users_Index')
CREATE UNIQUE CLUSTERED INDEX [aspnet_Users_Index] ON [dbo].[aspnet_Users] 
(
	[ApplicationId] ASC,
	[LoweredUserName] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
GO

/****** Object:  Index [aspnet_Users_Index2]    Script Date: 01/25/2007 22:18:26 ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Users]') AND name = N'aspnet_Users_Index2')
CREATE NONCLUSTERED INDEX [aspnet_Users_Index2] ON [dbo].[aspnet_Users] 
(
	[ApplicationId] ASC,
	[LastActivityDate] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[aspnet_UsersInRoles]    Script Date: 01/25/2007 22:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_UsersInRoles]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[aspnet_UsersInRoles](
	[UserId] [uniqueidentifier] NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO

/****** Object:  Index [aspnet_UsersInRoles_index]    Script Date: 01/25/2007 22:18:26 ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_UsersInRoles]') AND name = N'aspnet_UsersInRoles_index')
CREATE NONCLUSTERED INDEX [aspnet_UsersInRoles_index] ON [dbo].[aspnet_UsersInRoles] 
(
	[RoleId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[aspnet_WebEvent_Events]    Script Date: 01/25/2007 22:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_WebEvent_Events]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[aspnet_WebEvent_Events](
	[EventId] [char](32) NOT NULL,
	[EventTimeUtc] [datetime] NOT NULL,
	[EventTime] [datetime] NOT NULL,
	[EventType] [nvarchar](256) NOT NULL,
	[EventSequence] [decimal](19, 0) NOT NULL,
	[EventOccurrence] [decimal](19, 0) NOT NULL,
	[EventCode] [int] NOT NULL,
	[EventDetailCode] [int] NOT NULL,
	[Message] [nvarchar](1024) NULL,
	[ApplicationPath] [nvarchar](256) NULL,
	[ApplicationVirtualPath] [nvarchar](256) NULL,
	[MachineName] [nvarchar](256) NOT NULL,
	[RequestUrl] [nvarchar](1024) NULL,
	[ExceptionType] [nvarchar](256) NULL,
	[Details] [ntext] NULL,
PRIMARY KEY CLUSTERED 
(
	[EventId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[author]    Script Date: 01/25/2007 22:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[author]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[author](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[account_id] [int] NOT NULL,
	[name] [nvarchar](64) NOT NULL,
 CONSTRAINT [PK_author] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[charge_unit]    Script Date: 01/25/2007 22:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[charge_unit]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[charge_unit](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[common_name] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_charge_unit] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[charge_unit_description]    Script Date: 01/25/2007 22:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[charge_unit_description]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[charge_unit_description](
	[charge_unit_id] [int] NOT NULL,
	[language_id] [int] NOT NULL,
	[name] [nvarchar](128) NOT NULL,
	[description] [text] NULL,
 CONSTRAINT [PK_charge_unit_description] PRIMARY KEY CLUSTERED 
(
	[charge_unit_id] ASC,
	[language_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[delete_log]    Script Date: 01/25/2007 22:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[delete_log]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[delete_log](
	[subscription_id] [uniqueidentifier] NOT NULL,
	[change_number] [int] NOT NULL,
	[uuid] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_delete_log] PRIMARY KEY CLUSTERED 
(
	[subscription_id] ASC,
	[change_number] ASC,
	[uuid] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Deleted nodes unique id' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'delete_log', @level2type=N'COLUMN', @level2name=N'uuid'

GO
/****** Object:  Table [dbo].[group]    Script Date: 01/25/2007 22:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[group]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[group](
	[id] [int] NOT NULL,
	[language_id] [int] NOT NULL,
	[parent_id] [int] NULL,
	[name] [nvarchar](64) NOT NULL,
	[description] [text] NULL,
 CONSTRAINT [PK_group] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[group_administrator]    Script Date: 01/25/2007 22:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[group_administrator]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[group_administrator](
	[group_id] [int] NOT NULL,
	[administrator_id] [int] NOT NULL,
 CONSTRAINT [PK_group_administrator] PRIMARY KEY CLUSTERED 
(
	[group_id] ASC,
	[administrator_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[history]    Script Date: 01/25/2007 22:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[history]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[history](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[service_id] [int] NOT NULL,
	[account_id] [int] NOT NULL,
	[timestamp] [datetime] NOT NULL,
	[client_ip] [nvarchar](32) NOT NULL,
	[action] [char](1) NOT NULL,
	[price] [decimal](4, 0) NULL,
 CONSTRAINT [PK_report] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[language]    Script Date: 01/25/2007 22:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[language]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[language](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](64) NOT NULL,
 CONSTRAINT [PK_language] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[method]    Script Date: 01/25/2007 22:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[method]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[method](
	[id] [int] NOT NULL,
	[method_type_id] [int] NOT NULL,
	[script] [text] NULL,
 CONSTRAINT [PK_action] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Simple scripting to allow joined requests towards datastore and indirectly allowing service authors to charge specifically for this action.' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'method', @level2type=N'COLUMN', @level2name=N'script'

GO
/****** Object:  Table [dbo].[method_history]    Script Date: 01/25/2007 22:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[method_history]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[method_history](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[account_id] [int] NOT NULL,
	[subscription_id] [uniqueidentifier] NOT NULL,
	[timestamp] [datetime] NOT NULL,
	[method] [nvarchar](64) NOT NULL,
	[user_host_address] [nvarchar](128) NULL,
 CONSTRAINT [PK_method_history] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[method_type]    Script Date: 01/25/2007 22:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[method_type]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[method_type](
	[id] [int] IDENTITY(100,1) NOT NULL,
	[name] [nvarchar](64) NOT NULL,
 CONSTRAINT [PK_action_type] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[package]    Script Date: 01/25/2007 22:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[package]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[package](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[service_id] [int] NOT NULL,
	[platform_id] [int] NOT NULL CONSTRAINT [DF_package_platform_id]  DEFAULT (1),
	[version] [nvarchar](16) NOT NULL,
	[release_date] [datetime] NOT NULL,
	[state] [char](1) NOT NULL CONSTRAINT [DF_package_state]  DEFAULT ('N'),
 CONSTRAINT [PK_package] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'N=New, A=Activated, D=Deactivated, R=Retired' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'package', @level2type=N'COLUMN', @level2name=N'state'

GO
/****** Object:  Table [dbo].[package_item]    Script Date: 01/25/2007 22:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[package_item]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[package_item](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[package_id] [int] NOT NULL,
	[name] [nvarchar](128) NOT NULL,
	[type] [nvarchar](128) NOT NULL,
	[size] [bigint] NOT NULL,
	[data] [image] NULL,
 CONSTRAINT [PK_package_item] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'MIME type e.g. "image/gif"' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'package_item', @level2type=N'COLUMN', @level2name=N'type'

GO
/****** Object:  Table [dbo].[platform]    Script Date: 01/25/2007 22:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[platform]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[platform](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[language_id] [int] NOT NULL,
	[name] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_platform] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identifier for platform.' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'platform', @level2type=N'COLUMN', @level2name=N'id'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name of platform such as "Windows", "Linux" or "PDA".' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'platform', @level2type=N'COLUMN', @level2name=N'name'

GO
/****** Object:  Table [dbo].[role]    Script Date: 01/25/2007 22:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[role]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[role](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[subscription_id] [uniqueidentifier] NOT NULL,
	[account_id] [int] NOT NULL,
	[scope_id] [int] NULL,
	[role_template_id] [int] NOT NULL,
	[active_from] [datetime] NULL,
	[active_to] [datetime] NULL,
 CONSTRAINT [PK_control] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Id of account allowed to access a given content document for another subscription.' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'role', @level2type=N'COLUMN', @level2name=N'account_id'

GO
/****** Object:  Table [dbo].[role_description]    Script Date: 01/25/2007 22:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[role_description]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[role_description](
	[role_id] [int] NOT NULL,
	[language_id] [int] NOT NULL,
	[description] [nvarchar](64) NOT NULL,
 CONSTRAINT [PK_control_description] PRIMARY KEY CLUSTERED 
(
	[role_id] ASC,
	[language_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[role_template]    Script Date: 01/25/2007 22:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[role_template]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[role_template](
	[id] [int] IDENTITY(100,1) NOT NULL,
	[service_id] [int] NOT NULL,
	[name] [nvarchar](64) NOT NULL,
	[priority] [smallint] NULL,
 CONSTRAINT [PK_access_control] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[role_template_description]    Script Date: 01/25/2007 22:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[role_template_description]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[role_template_description](
	[role_template_id] [int] NOT NULL,
	[language_id] [int] NOT NULL,
	[description] [text] NOT NULL,
 CONSTRAINT [PK_access_control_description] PRIMARY KEY CLUSTERED 
(
	[role_template_id] ASC,
	[language_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[role_template_method]    Script Date: 01/25/2007 22:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[role_template_method]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[role_template_method](
	[role_template_id] [int] NOT NULL,
	[method_type_id] [int] NOT NULL,
	[scope_id] [int] NOT NULL,
 CONSTRAINT [PK_access_control_action] PRIMARY KEY CLUSTERED 
(
	[role_template_id] ASC,
	[method_type_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[scope]    Script Date: 01/25/2007 22:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[scope]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[scope](
	[id] [int] IDENTITY(100,1) NOT NULL,
	[language_id] [int] NOT NULL,
	[name] [nvarchar](128) NOT NULL,
	[base] [nvarchar](3) NOT NULL CONSTRAINT [DF_scope_base]  DEFAULT (N'NIL'),
 CONSTRAINT [PK_scope] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[service]    Script Date: 01/25/2007 22:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[service]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[service](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[author_id] [int] NOT NULL,
	[name] [nvarchar](64) NOT NULL,
	[version] [nvarchar](16) NULL,
	[xsd] [text] NULL,
	[url_xsd] [nvarchar](160) NULL,
	[url_icon] [nvarchar](128) NULL,
	[url_homepage] [nvarchar](128) NULL,
	[state] [char](1) NOT NULL CONSTRAINT [DF_service_state]  DEFAULT ('N'),
	[role_map] [text] NULL,
 CONSTRAINT [PK_service] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [IX_service] UNIQUE NONCLUSTERED 
(
	[name] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Url (can be local) to Xsd.' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'service', @level2type=N'COLUMN', @level2name=N'url_xsd'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Url (can be local) to icon image for service.' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'service', @level2type=N'COLUMN', @level2name=N'url_icon'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Url (can be local) to a homepage this service where an author can provide non-generic information.' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'service', @level2type=N'COLUMN', @level2name=N'url_homepage'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'N = New, A = Activated, D = Deactivated, R = Retired' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'service', @level2type=N'COLUMN', @level2name=N'state'

GO
/****** Object:  Table [dbo].[service_charge]    Script Date: 01/25/2007 22:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[service_charge]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[service_charge](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[service_id] [int] NOT NULL,
	[method_type_id] [int] NOT NULL,
	[schema_type] [nvarchar](64) NOT NULL,
	[script] [text] NULL,
	[price] [real] NOT NULL,
	[charge_unit_id] [int] NOT NULL,
 CONSTRAINT [PK_service_charge] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Create, Read, Update and Delete. For a "provision fee", a "Create" with element e.g. "iqContacts" where that''s the root of the referred XSD since this will be automatically created upon provisioning.' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'service_charge', @level2type=N'COLUMN', @level2name=N'method_type_id'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name of an element in the referred XSD.' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'service_charge', @level2type=N'COLUMN', @level2name=N'schema_type'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Allows for advanced charging where the selected ''element'' instance is given to the function.' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'service_charge', @level2type=N'COLUMN', @level2name=N'script'

GO
/****** Object:  Table [dbo].[service_dependency]    Script Date: 01/25/2007 22:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[service_dependency]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[service_dependency](
	[service_id] [int] NOT NULL,
	[dependency_service_id] [int] NOT NULL,
 CONSTRAINT [PK_service_dependency] PRIMARY KEY CLUSTERED 
(
	[service_id] ASC,
	[dependency_service_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Id of service on which this service depends.' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'service_dependency', @level2type=N'COLUMN', @level2name=N'dependency_service_id'

GO
/****** Object:  Table [dbo].[service_description]    Script Date: 01/25/2007 22:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[service_description]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[service_description](
	[service_id] [int] NOT NULL,
	[language_id] [int] NOT NULL,
	[short_description] [nvarchar](256) NOT NULL,
	[long_description] [text] NULL,
 CONSTRAINT [PK_service_description] PRIMARY KEY CLUSTERED 
(
	[service_id] ASC,
	[language_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[service_method]    Script Date: 01/25/2007 22:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[service_method]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[service_method](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[service_id] [int] NOT NULL,
	[method_type_id] [int] NOT NULL,
	[name] [nvarchar](64) NOT NULL,
	[select] [nvarchar](64) NOT NULL,
	[script] [text] NULL,
	[script_url] [nvarchar](128) NULL,
 CONSTRAINT [PK_service_method] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[service_scope]    Script Date: 01/25/2007 22:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[service_scope]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[service_scope](
	[service_id] [int] NOT NULL,
	[scope_id] [int] NOT NULL,
 CONSTRAINT [PK_service_scope] PRIMARY KEY CLUSTERED 
(
	[service_id] ASC,
	[scope_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[shape]    Script Date: 01/25/2007 22:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[shape]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[shape](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[scope_id] [int] NOT NULL,
	[select] [nvarchar](64) NOT NULL,
	[type] [nchar](1) NOT NULL,
 CONSTRAINT [PK_scope_modifier] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'I = Include, E = Exclude' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'shape', @level2type=N'COLUMN', @level2name=N'type'

GO
/****** Object:  Table [dbo].[subscription]    Script Date: 01/25/2007 22:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[subscription]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[subscription](
	[id] [uniqueidentifier] NOT NULL,
	[account_id] [int] NOT NULL,
	[service_id] [int] NOT NULL,
	[name] [nvarchar](128) NOT NULL,
	[xml] [text] NULL,
	[url_xml] [nvarchar](128) NULL,
	[role_list] [text] NULL,
	[notify_list] [text] NULL,
 CONSTRAINT [PK_subscription] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [IX_subscription] UNIQUE NONCLUSTERED 
(
	[account_id] ASC,
	[service_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  FullTextIndex     Script Date: 01/25/2007 22:18:26 ******/
IF not EXISTS (SELECT * FROM sys.fulltext_indexes fti WHERE fti.object_id = OBJECT_ID(N'[dbo].[subscription]'))
CREATE FULLTEXT INDEX ON [dbo].[subscription](
[xml] LANGUAGE [English])
KEY INDEX [PK_subscription] ON [Full site search]
WITH CHANGE_TRACKING AUTO

GO
/****** Object:  Table [dbo].[subscription_charge]    Script Date: 01/25/2007 22:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[subscription_charge]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[subscription_charge](
	[subscription_id] [uniqueidentifier] NOT NULL,
	[service_charge_id] [int] NOT NULL,
	[timestamp] [datetime] NOT NULL
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[subscription_listener]    Script Date: 01/25/2007 22:18:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[subscription_listener]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[subscription_listener](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[account_id] [int] NOT NULL,
	[subscription_id] [uniqueidentifier] NOT NULL,
	[filter] [nvarchar](128) NOT NULL,
	[context] [text] NULL,
	[context_uri] [nvarchar](128) NOT NULL,
	[to] [nvarchar](128) NOT NULL,
	[active_from] [datetime] NULL,
	[active_to] [datetime] NULL,
	[state] [char](1) NOT NULL CONSTRAINT [DF_subscription_listener_state]  DEFAULT ('R'),
 CONSTRAINT [PK_subscription_listener] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Id of account receiving event' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'subscription_listener', @level2type=N'COLUMN', @level2name=N'account_id'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'XPath determining on which nodeset to listen.' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'subscription_listener', @level2type=N'COLUMN', @level2name=N'filter'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Uri of end-point with special "iq:iqEvents" for delivering to accounts iqEvents subscription.' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'subscription_listener', @level2type=N'COLUMN', @level2name=N'to'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'R = Running, S = Suspended' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'subscription_listener', @level2type=N'COLUMN', @level2name=N'state'

GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_account_account]') AND parent_object_id = OBJECT_ID(N'[dbo].[account]'))
ALTER TABLE [dbo].[account]  WITH NOCHECK ADD  CONSTRAINT [FK_account_account] FOREIGN KEY([owner_account_id])
REFERENCES [dbo].[account] ([id])
GO
ALTER TABLE [dbo].[account] CHECK CONSTRAINT [FK_account_account]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_account_group]') AND parent_object_id = OBJECT_ID(N'[dbo].[account]'))
ALTER TABLE [dbo].[account]  WITH NOCHECK ADD  CONSTRAINT [FK_account_group] FOREIGN KEY([group_id])
REFERENCES [dbo].[group] ([id])
GO
ALTER TABLE [dbo].[account] CHECK CONSTRAINT [FK_account_group]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_subscription_scope_scope]') AND parent_object_id = OBJECT_ID(N'[dbo].[subscription_scope]'))
ALTER TABLE [dbo].[subscription_scope]  WITH NOCHECK ADD  CONSTRAINT [FK_subscription_scope_scope] FOREIGN KEY([scope_id])
REFERENCES [dbo].[scope] ([id])
GO
ALTER TABLE [dbo].[subscription_scope] CHECK CONSTRAINT [FK_subscription_scope_scope]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_administrator_account]') AND parent_object_id = OBJECT_ID(N'[dbo].[administrator]'))
ALTER TABLE [dbo].[administrator]  WITH NOCHECK ADD  CONSTRAINT [FK_administrator_account] FOREIGN KEY([account_id])
REFERENCES [dbo].[account] ([id])
GO
ALTER TABLE [dbo].[administrator] CHECK CONSTRAINT [FK_administrator_account]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__aspnet_Me__Appli__6EE06CCD]') AND parent_object_id = OBJECT_ID(N'[dbo].[aspnet_Membership]'))
ALTER TABLE [dbo].[aspnet_Membership]  WITH CHECK ADD FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[aspnet_Applications] ([ApplicationId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__aspnet_Me__UserI__6FD49106]') AND parent_object_id = OBJECT_ID(N'[dbo].[aspnet_Membership]'))
ALTER TABLE [dbo].[aspnet_Membership]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[aspnet_Users] ([UserId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__aspnet_Pa__Appli__2077C861]') AND parent_object_id = OBJECT_ID(N'[dbo].[aspnet_Paths]'))
ALTER TABLE [dbo].[aspnet_Paths]  WITH CHECK ADD FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[aspnet_Applications] ([ApplicationId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__aspnet_Pe__PathI__2630A1B7]') AND parent_object_id = OBJECT_ID(N'[dbo].[aspnet_PersonalizationAllUsers]'))
ALTER TABLE [dbo].[aspnet_PersonalizationAllUsers]  WITH CHECK ADD FOREIGN KEY([PathId])
REFERENCES [dbo].[aspnet_Paths] ([PathId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__aspnet_Pe__PathI__2A01329B]') AND parent_object_id = OBJECT_ID(N'[dbo].[aspnet_PersonalizationPerUser]'))
ALTER TABLE [dbo].[aspnet_PersonalizationPerUser]  WITH CHECK ADD FOREIGN KEY([PathId])
REFERENCES [dbo].[aspnet_Paths] ([PathId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__aspnet_Pe__UserI__2AF556D4]') AND parent_object_id = OBJECT_ID(N'[dbo].[aspnet_PersonalizationPerUser]'))
ALTER TABLE [dbo].[aspnet_PersonalizationPerUser]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[aspnet_Users] ([UserId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__aspnet_Pr__UserI__03DB89B3]') AND parent_object_id = OBJECT_ID(N'[dbo].[aspnet_Profile]'))
ALTER TABLE [dbo].[aspnet_Profile]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[aspnet_Users] ([UserId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__aspnet_Ro__Appli__0D64F3ED]') AND parent_object_id = OBJECT_ID(N'[dbo].[aspnet_Roles]'))
ALTER TABLE [dbo].[aspnet_Roles]  WITH CHECK ADD FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[aspnet_Applications] ([ApplicationId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__aspnet_Us__Appli__5EAA0504]') AND parent_object_id = OBJECT_ID(N'[dbo].[aspnet_Users]'))
ALTER TABLE [dbo].[aspnet_Users]  WITH CHECK ADD FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[aspnet_Applications] ([ApplicationId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__aspnet_Us__RoleI__1229A90A]') AND parent_object_id = OBJECT_ID(N'[dbo].[aspnet_UsersInRoles]'))
ALTER TABLE [dbo].[aspnet_UsersInRoles]  WITH CHECK ADD FOREIGN KEY([RoleId])
REFERENCES [dbo].[aspnet_Roles] ([RoleId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__aspnet_Us__UserI__113584D1]') AND parent_object_id = OBJECT_ID(N'[dbo].[aspnet_UsersInRoles]'))
ALTER TABLE [dbo].[aspnet_UsersInRoles]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[aspnet_Users] ([UserId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_author_account]') AND parent_object_id = OBJECT_ID(N'[dbo].[author]'))
ALTER TABLE [dbo].[author]  WITH NOCHECK ADD  CONSTRAINT [FK_author_account] FOREIGN KEY([account_id])
REFERENCES [dbo].[account] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[author] CHECK CONSTRAINT [FK_author_account]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_charge_unit_description_charge_unit]') AND parent_object_id = OBJECT_ID(N'[dbo].[charge_unit_description]'))
ALTER TABLE [dbo].[charge_unit_description]  WITH NOCHECK ADD  CONSTRAINT [FK_charge_unit_description_charge_unit] FOREIGN KEY([charge_unit_id])
REFERENCES [dbo].[charge_unit] ([id])
GO
ALTER TABLE [dbo].[charge_unit_description] CHECK CONSTRAINT [FK_charge_unit_description_charge_unit]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_charge_unit_description_language]') AND parent_object_id = OBJECT_ID(N'[dbo].[charge_unit_description]'))
ALTER TABLE [dbo].[charge_unit_description]  WITH CHECK ADD  CONSTRAINT [FK_charge_unit_description_language] FOREIGN KEY([language_id])
REFERENCES [dbo].[language] ([id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_delete_log_subscription]') AND parent_object_id = OBJECT_ID(N'[dbo].[delete_log]'))
ALTER TABLE [dbo].[delete_log]  WITH CHECK ADD  CONSTRAINT [FK_delete_log_subscription] FOREIGN KEY([subscription_id])
REFERENCES [dbo].[subscription] ([id])
ON DELETE CASCADE
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_group_administrator_administrator]') AND parent_object_id = OBJECT_ID(N'[dbo].[group_administrator]'))
ALTER TABLE [dbo].[group_administrator]  WITH CHECK ADD  CONSTRAINT [FK_group_administrator_administrator] FOREIGN KEY([administrator_id])
REFERENCES [dbo].[administrator] ([id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_group_administrator_group]') AND parent_object_id = OBJECT_ID(N'[dbo].[group_administrator]'))
ALTER TABLE [dbo].[group_administrator]  WITH CHECK ADD  CONSTRAINT [FK_group_administrator_group] FOREIGN KEY([group_id])
REFERENCES [dbo].[group] ([id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_method_method_type]') AND parent_object_id = OBJECT_ID(N'[dbo].[method]'))
ALTER TABLE [dbo].[method]  WITH NOCHECK ADD  CONSTRAINT [FK_method_method_type] FOREIGN KEY([method_type_id])
REFERENCES [dbo].[method_type] ([id])
GO
ALTER TABLE [dbo].[method] CHECK CONSTRAINT [FK_method_method_type]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_package_platform]') AND parent_object_id = OBJECT_ID(N'[dbo].[package]'))
ALTER TABLE [dbo].[package]  WITH CHECK ADD  CONSTRAINT [FK_package_platform] FOREIGN KEY([platform_id])
REFERENCES [dbo].[platform] ([id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_package_service]') AND parent_object_id = OBJECT_ID(N'[dbo].[package]'))
ALTER TABLE [dbo].[package]  WITH NOCHECK ADD  CONSTRAINT [FK_package_service] FOREIGN KEY([service_id])
REFERENCES [dbo].[service] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[package] CHECK CONSTRAINT [FK_package_service]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_package_item_package]') AND parent_object_id = OBJECT_ID(N'[dbo].[package_item]'))
ALTER TABLE [dbo].[package_item]  WITH NOCHECK ADD  CONSTRAINT [FK_package_item_package] FOREIGN KEY([package_id])
REFERENCES [dbo].[package] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[package_item] CHECK CONSTRAINT [FK_package_item_package]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_platform_language]') AND parent_object_id = OBJECT_ID(N'[dbo].[platform]'))
ALTER TABLE [dbo].[platform]  WITH CHECK ADD  CONSTRAINT [FK_platform_language] FOREIGN KEY([language_id])
REFERENCES [dbo].[language] ([id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_role_account]') AND parent_object_id = OBJECT_ID(N'[dbo].[role]'))
ALTER TABLE [dbo].[role]  WITH NOCHECK ADD  CONSTRAINT [FK_role_account] FOREIGN KEY([account_id])
REFERENCES [dbo].[account] ([id])
GO
ALTER TABLE [dbo].[role] CHECK CONSTRAINT [FK_role_account]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_role_role_template]') AND parent_object_id = OBJECT_ID(N'[dbo].[role]'))
ALTER TABLE [dbo].[role]  WITH NOCHECK ADD  CONSTRAINT [FK_role_role_template] FOREIGN KEY([role_template_id])
REFERENCES [dbo].[role_template] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[role] CHECK CONSTRAINT [FK_role_role_template]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_role_scope]') AND parent_object_id = OBJECT_ID(N'[dbo].[role]'))
ALTER TABLE [dbo].[role]  WITH NOCHECK ADD  CONSTRAINT [FK_role_scope] FOREIGN KEY([scope_id])
REFERENCES [dbo].[scope] ([id])
GO
ALTER TABLE [dbo].[role] CHECK CONSTRAINT [FK_role_scope]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_control_description_language]') AND parent_object_id = OBJECT_ID(N'[dbo].[role_description]'))
ALTER TABLE [dbo].[role_description]  WITH CHECK ADD  CONSTRAINT [FK_control_description_language] FOREIGN KEY([language_id])
REFERENCES [dbo].[language] ([id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_role_description_role]') AND parent_object_id = OBJECT_ID(N'[dbo].[role_description]'))
ALTER TABLE [dbo].[role_description]  WITH NOCHECK ADD  CONSTRAINT [FK_role_description_role] FOREIGN KEY([role_id])
REFERENCES [dbo].[role] ([id])
GO
ALTER TABLE [dbo].[role_description] CHECK CONSTRAINT [FK_role_description_role]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_role_template_service]') AND parent_object_id = OBJECT_ID(N'[dbo].[role_template]'))
ALTER TABLE [dbo].[role_template]  WITH NOCHECK ADD  CONSTRAINT [FK_role_template_service] FOREIGN KEY([service_id])
REFERENCES [dbo].[service] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[role_template] CHECK CONSTRAINT [FK_role_template_service]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_access_control_description_language]') AND parent_object_id = OBJECT_ID(N'[dbo].[role_template_description]'))
ALTER TABLE [dbo].[role_template_description]  WITH NOCHECK ADD  CONSTRAINT [FK_access_control_description_language] FOREIGN KEY([language_id])
REFERENCES [dbo].[language] ([id])
GO
ALTER TABLE [dbo].[role_template_description] CHECK CONSTRAINT [FK_access_control_description_language]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_role_template_role_template_description]') AND parent_object_id = OBJECT_ID(N'[dbo].[role_template_description]'))
ALTER TABLE [dbo].[role_template_description]  WITH NOCHECK ADD  CONSTRAINT [FK_role_template_role_template_description] FOREIGN KEY([role_template_id])
REFERENCES [dbo].[role_template] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[role_template_description] CHECK CONSTRAINT [FK_role_template_role_template_description]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_access_control_action_scope]') AND parent_object_id = OBJECT_ID(N'[dbo].[role_template_method]'))
ALTER TABLE [dbo].[role_template_method]  WITH NOCHECK ADD  CONSTRAINT [FK_access_control_action_scope] FOREIGN KEY([scope_id])
REFERENCES [dbo].[scope] ([id])
GO
ALTER TABLE [dbo].[role_template_method] CHECK CONSTRAINT [FK_access_control_action_scope]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_role_template_method_method_type]') AND parent_object_id = OBJECT_ID(N'[dbo].[role_template_method]'))
ALTER TABLE [dbo].[role_template_method]  WITH NOCHECK ADD  CONSTRAINT [FK_role_template_method_method_type] FOREIGN KEY([method_type_id])
REFERENCES [dbo].[method_type] ([id])
GO
ALTER TABLE [dbo].[role_template_method] CHECK CONSTRAINT [FK_role_template_method_method_type]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_role_template_method_role_template]') AND parent_object_id = OBJECT_ID(N'[dbo].[role_template_method]'))
ALTER TABLE [dbo].[role_template_method]  WITH NOCHECK ADD  CONSTRAINT [FK_role_template_method_role_template] FOREIGN KEY([role_template_id])
REFERENCES [dbo].[role_template] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[role_template_method] CHECK CONSTRAINT [FK_role_template_method_role_template]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_service_author]') AND parent_object_id = OBJECT_ID(N'[dbo].[service]'))
ALTER TABLE [dbo].[service]  WITH NOCHECK ADD  CONSTRAINT [FK_service_author] FOREIGN KEY([author_id])
REFERENCES [dbo].[author] ([id])
GO
ALTER TABLE [dbo].[service] CHECK CONSTRAINT [FK_service_author]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_service_charge_charge_unit]') AND parent_object_id = OBJECT_ID(N'[dbo].[service_charge]'))
ALTER TABLE [dbo].[service_charge]  WITH NOCHECK ADD  CONSTRAINT [FK_service_charge_charge_unit] FOREIGN KEY([charge_unit_id])
REFERENCES [dbo].[charge_unit] ([id])
GO
ALTER TABLE [dbo].[service_charge] CHECK CONSTRAINT [FK_service_charge_charge_unit]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_service_charge_service]') AND parent_object_id = OBJECT_ID(N'[dbo].[service_charge]'))
ALTER TABLE [dbo].[service_charge]  WITH NOCHECK ADD  CONSTRAINT [FK_service_charge_service] FOREIGN KEY([service_id])
REFERENCES [dbo].[service] ([id])
GO
ALTER TABLE [dbo].[service_charge] CHECK CONSTRAINT [FK_service_charge_service]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_service_dependency_service]') AND parent_object_id = OBJECT_ID(N'[dbo].[service_dependency]'))
ALTER TABLE [dbo].[service_dependency]  WITH NOCHECK ADD  CONSTRAINT [FK_service_dependency_service] FOREIGN KEY([service_id])
REFERENCES [dbo].[service] ([id])
GO
ALTER TABLE [dbo].[service_dependency] CHECK CONSTRAINT [FK_service_dependency_service]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_service_dependency_service1]') AND parent_object_id = OBJECT_ID(N'[dbo].[service_dependency]'))
ALTER TABLE [dbo].[service_dependency]  WITH NOCHECK ADD  CONSTRAINT [FK_service_dependency_service1] FOREIGN KEY([dependency_service_id])
REFERENCES [dbo].[service] ([id])
GO
ALTER TABLE [dbo].[service_dependency] CHECK CONSTRAINT [FK_service_dependency_service1]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_service_description_language]') AND parent_object_id = OBJECT_ID(N'[dbo].[service_description]'))
ALTER TABLE [dbo].[service_description]  WITH NOCHECK ADD  CONSTRAINT [FK_service_description_language] FOREIGN KEY([language_id])
REFERENCES [dbo].[language] ([id])
GO
ALTER TABLE [dbo].[service_description] CHECK CONSTRAINT [FK_service_description_language]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_service_description_service]') AND parent_object_id = OBJECT_ID(N'[dbo].[service_description]'))
ALTER TABLE [dbo].[service_description]  WITH NOCHECK ADD  CONSTRAINT [FK_service_description_service] FOREIGN KEY([service_id])
REFERENCES [dbo].[service] ([id])
GO
ALTER TABLE [dbo].[service_description] CHECK CONSTRAINT [FK_service_description_service]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_service_method_method]') AND parent_object_id = OBJECT_ID(N'[dbo].[service_method]'))
ALTER TABLE [dbo].[service_method]  WITH CHECK ADD  CONSTRAINT [FK_service_method_method] FOREIGN KEY([method_type_id])
REFERENCES [dbo].[method_type] ([id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_service_method_service]') AND parent_object_id = OBJECT_ID(N'[dbo].[service_method]'))
ALTER TABLE [dbo].[service_method]  WITH NOCHECK ADD  CONSTRAINT [FK_service_method_service] FOREIGN KEY([service_id])
REFERENCES [dbo].[service] ([id])
GO
ALTER TABLE [dbo].[service_method] CHECK CONSTRAINT [FK_service_method_service]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_service_scope_scope]') AND parent_object_id = OBJECT_ID(N'[dbo].[service_scope]'))
ALTER TABLE [dbo].[service_scope]  WITH NOCHECK ADD  CONSTRAINT [FK_service_scope_scope] FOREIGN KEY([scope_id])
REFERENCES [dbo].[scope] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[service_scope] CHECK CONSTRAINT [FK_service_scope_scope]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_service_scope_service]') AND parent_object_id = OBJECT_ID(N'[dbo].[service_scope]'))
ALTER TABLE [dbo].[service_scope]  WITH NOCHECK ADD  CONSTRAINT [FK_service_scope_service] FOREIGN KEY([service_id])
REFERENCES [dbo].[service] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[service_scope] CHECK CONSTRAINT [FK_service_scope_service]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_shape_scope]') AND parent_object_id = OBJECT_ID(N'[dbo].[shape]'))
ALTER TABLE [dbo].[shape]  WITH NOCHECK ADD  CONSTRAINT [FK_shape_scope] FOREIGN KEY([scope_id])
REFERENCES [dbo].[scope] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[shape] CHECK CONSTRAINT [FK_shape_scope]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_subscription_account]') AND parent_object_id = OBJECT_ID(N'[dbo].[subscription]'))
ALTER TABLE [dbo].[subscription]  WITH NOCHECK ADD  CONSTRAINT [FK_subscription_account] FOREIGN KEY([account_id])
REFERENCES [dbo].[account] ([id])
GO
ALTER TABLE [dbo].[subscription] CHECK CONSTRAINT [FK_subscription_account]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_subscription_service]') AND parent_object_id = OBJECT_ID(N'[dbo].[subscription]'))
ALTER TABLE [dbo].[subscription]  WITH NOCHECK ADD  CONSTRAINT [FK_subscription_service] FOREIGN KEY([service_id])
REFERENCES [dbo].[service] ([id])
GO
ALTER TABLE [dbo].[subscription] CHECK CONSTRAINT [FK_subscription_service]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_subscription_charge_service_charge]') AND parent_object_id = OBJECT_ID(N'[dbo].[subscription_charge]'))
ALTER TABLE [dbo].[subscription_charge]  WITH NOCHECK ADD  CONSTRAINT [FK_subscription_charge_service_charge] FOREIGN KEY([service_charge_id])
REFERENCES [dbo].[service_charge] ([id])
GO
ALTER TABLE [dbo].[subscription_charge] CHECK CONSTRAINT [FK_subscription_charge_service_charge]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_subscription_listener_account]') AND parent_object_id = OBJECT_ID(N'[dbo].[subscription_listener]'))
ALTER TABLE [dbo].[subscription_listener]  WITH NOCHECK ADD  CONSTRAINT [FK_subscription_listener_account] FOREIGN KEY([account_id])
REFERENCES [dbo].[account] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[subscription_listener] CHECK CONSTRAINT [FK_subscription_listener_account]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_subscription_listener_subscription]') AND parent_object_id = OBJECT_ID(N'[dbo].[subscription_listener]'))
ALTER TABLE [dbo].[subscription_listener]  WITH NOCHECK ADD  CONSTRAINT [FK_subscription_listener_subscription] FOREIGN KEY([subscription_id])
REFERENCES [dbo].[subscription] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[subscription_listener] CHECK CONSTRAINT [FK_subscription_listener_subscription]
GO
