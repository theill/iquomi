/****** Object:  StoredProcedure [dbo].[GetSubscription]    Script Date: 01/25/2007 22:16:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetSubscription]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetSubscription]
GO
/****** Object:  StoredProcedure [dbo].[LogAction]    Script Date: 01/25/2007 22:16:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LogAction]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[LogAction]
GO
/****** Object:  StoredProcedure [dbo].[iqAccountCreate]    Script Date: 01/25/2007 22:16:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqAccountCreate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqAccountCreate]
GO
/****** Object:  StoredProcedure [dbo].[iqAccountDelete]    Script Date: 01/25/2007 22:16:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqAccountDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqAccountDelete]
GO
/****** Object:  StoredProcedure [dbo].[iqAccountFindByEmailPassword]    Script Date: 01/25/2007 22:16:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqAccountFindByEmailPassword]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqAccountFindByEmailPassword]
GO
/****** Object:  StoredProcedure [dbo].[iqAccountFindByIqid]    Script Date: 01/25/2007 22:16:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqAccountFindByIqid]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqAccountFindByIqid]
GO
/****** Object:  StoredProcedure [dbo].[iqAccountFindByToken]    Script Date: 01/25/2007 22:16:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqAccountFindByToken]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqAccountFindByToken]
GO
/****** Object:  StoredProcedure [dbo].[iqAccountRead]    Script Date: 01/25/2007 22:16:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqAccountRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqAccountRead]
GO
/****** Object:  StoredProcedure [dbo].[iqAccountUpdate]    Script Date: 01/25/2007 22:16:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqAccountUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqAccountUpdate]
GO
/****** Object:  StoredProcedure [dbo].[iqAuthorCreate]    Script Date: 01/25/2007 22:16:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqAuthorCreate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqAuthorCreate]
GO
/****** Object:  StoredProcedure [dbo].[iqAuthorDelete]    Script Date: 01/25/2007 22:16:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqAuthorDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqAuthorDelete]
GO
/****** Object:  StoredProcedure [dbo].[iqAuthorFindAllPackages]    Script Date: 01/25/2007 22:16:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqAuthorFindAllPackages]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqAuthorFindAllPackages]
GO
/****** Object:  StoredProcedure [dbo].[iqAuthorLookup]    Script Date: 01/25/2007 22:16:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqAuthorLookup]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqAuthorLookup]
GO
/****** Object:  StoredProcedure [dbo].[iqChargeUnitFindAll]    Script Date: 01/25/2007 22:16:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqChargeUnitFindAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqChargeUnitFindAll]
GO
/****** Object:  StoredProcedure [dbo].[iqDeleteLogCreate]    Script Date: 01/25/2007 22:16:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqDeleteLogCreate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqDeleteLogCreate]
GO
/****** Object:  StoredProcedure [dbo].[iqDeleteLogDelete]    Script Date: 01/25/2007 22:16:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqDeleteLogDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqDeleteLogDelete]
GO
/****** Object:  StoredProcedure [dbo].[iqDeleteLogFindAll]    Script Date: 01/25/2007 22:16:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqDeleteLogFindAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqDeleteLogFindAll]
GO
/****** Object:  StoredProcedure [dbo].[iqFindLatestPackage]    Script Date: 01/25/2007 22:16:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqFindLatestPackage]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqFindLatestPackage]
GO
/****** Object:  StoredProcedure [dbo].[iqFindPackage]    Script Date: 01/25/2007 22:16:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqFindPackage]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqFindPackage]
GO
/****** Object:  StoredProcedure [dbo].[iqFindSubscriptionByAccountService]    Script Date: 01/25/2007 22:16:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqFindSubscriptionByAccountService]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqFindSubscriptionByAccountService]
GO
/****** Object:  StoredProcedure [dbo].[iqListAllLanguages]    Script Date: 01/25/2007 22:16:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqListAllLanguages]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqListAllLanguages]
GO
/****** Object:  StoredProcedure [dbo].[iqListAllRoleTemplateMethods]    Script Date: 01/25/2007 22:16:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqListAllRoleTemplateMethods]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqListAllRoleTemplateMethods]
GO
/****** Object:  StoredProcedure [dbo].[iqListAllRoleTemplatesByService]    Script Date: 01/25/2007 22:16:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqListAllRoleTemplatesByService]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqListAllRoleTemplatesByService]
GO
/****** Object:  StoredProcedure [dbo].[iqListAllScopesByService]    Script Date: 01/25/2007 22:16:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqListAllScopesByService]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqListAllScopesByService]
GO
/****** Object:  StoredProcedure [dbo].[iqListAllScopesBySubscription]    Script Date: 01/25/2007 22:16:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqListAllScopesBySubscription]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqListAllScopesBySubscription]
GO
/****** Object:  StoredProcedure [dbo].[iqListAllScopesForSubscription]    Script Date: 01/25/2007 22:16:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqListAllScopesForSubscription]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqListAllScopesForSubscription]
GO
/****** Object:  StoredProcedure [dbo].[iqListAllServiceChargesByService]    Script Date: 01/25/2007 22:16:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqListAllServiceChargesByService]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqListAllServiceChargesByService]
GO
/****** Object:  StoredProcedure [dbo].[iqListAllServiceMethodsByService]    Script Date: 01/25/2007 22:16:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqListAllServiceMethodsByService]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqListAllServiceMethodsByService]
GO
/****** Object:  StoredProcedure [dbo].[iqListAllServicesByAuthorId]    Script Date: 01/25/2007 22:16:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqListAllServicesByAuthorId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqListAllServicesByAuthorId]
GO
/****** Object:  StoredProcedure [dbo].[iqListListenersBySubscription]    Script Date: 01/25/2007 22:16:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqListListenersBySubscription]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqListListenersBySubscription]
GO
/****** Object:  StoredProcedure [dbo].[iqListMySubscriptions]    Script Date: 01/25/2007 22:16:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqListMySubscriptions]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqListMySubscriptions]
GO
/****** Object:  StoredProcedure [dbo].[iqListProvisionedServices]    Script Date: 01/25/2007 22:16:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqListProvisionedServices]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqListProvisionedServices]
GO
/****** Object:  StoredProcedure [dbo].[iqListRolesBySubscription]    Script Date: 01/25/2007 22:16:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqListRolesBySubscription]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqListRolesBySubscription]
GO
/****** Object:  StoredProcedure [dbo].[iqListServiceScopes]    Script Date: 01/25/2007 22:16:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqListServiceScopes]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqListServiceScopes]
GO
/****** Object:  StoredProcedure [dbo].[iqMethodHistoryCreate]    Script Date: 01/25/2007 22:16:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqMethodHistoryCreate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqMethodHistoryCreate]
GO
/****** Object:  StoredProcedure [dbo].[iqMethodHistoryFindAll]    Script Date: 01/25/2007 22:16:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqMethodHistoryFindAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqMethodHistoryFindAll]
GO
/****** Object:  StoredProcedure [dbo].[iqMethodTypeFindAll]    Script Date: 01/25/2007 22:16:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqMethodTypeFindAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqMethodTypeFindAll]
GO
/****** Object:  StoredProcedure [dbo].[iqMethodTypeRead]    Script Date: 01/25/2007 22:16:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqMethodTypeRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqMethodTypeRead]
GO
/****** Object:  StoredProcedure [dbo].[iqPackageCreate]    Script Date: 01/25/2007 22:16:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqPackageCreate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqPackageCreate]
GO
/****** Object:  StoredProcedure [dbo].[iqPackageDelete]    Script Date: 01/25/2007 22:16:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqPackageDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqPackageDelete]
GO
/****** Object:  StoredProcedure [dbo].[iqPackageFindAllByAuthor]    Script Date: 01/25/2007 22:16:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqPackageFindAllByAuthor]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqPackageFindAllByAuthor]
GO
/****** Object:  StoredProcedure [dbo].[iqPackageItemCreate]    Script Date: 01/25/2007 22:16:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqPackageItemCreate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqPackageItemCreate]
GO
/****** Object:  StoredProcedure [dbo].[iqPackageItemDelete]    Script Date: 01/25/2007 22:16:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqPackageItemDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqPackageItemDelete]
GO
/****** Object:  StoredProcedure [dbo].[iqPackageItemFindAll]    Script Date: 01/25/2007 22:16:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqPackageItemFindAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqPackageItemFindAll]
GO
/****** Object:  StoredProcedure [dbo].[iqPackageItemFindAllPartial]    Script Date: 01/25/2007 22:16:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqPackageItemFindAllPartial]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqPackageItemFindAllPartial]
GO
/****** Object:  StoredProcedure [dbo].[iqPackageItemRead]    Script Date: 01/25/2007 22:16:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqPackageItemRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqPackageItemRead]
GO
/****** Object:  StoredProcedure [dbo].[iqPackageItemUpdate]    Script Date: 01/25/2007 22:16:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqPackageItemUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqPackageItemUpdate]
GO
/****** Object:  StoredProcedure [dbo].[iqPackageRead]    Script Date: 01/25/2007 22:16:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqPackageRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqPackageRead]
GO
/****** Object:  StoredProcedure [dbo].[iqPackageUpdate]    Script Date: 01/25/2007 22:16:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqPackageUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqPackageUpdate]
GO
/****** Object:  StoredProcedure [dbo].[iqPlatformFindAll]    Script Date: 01/25/2007 22:16:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqPlatformFindAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqPlatformFindAll]
GO
/****** Object:  StoredProcedure [dbo].[iqQuerySubscriptions]    Script Date: 01/25/2007 22:16:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqQuerySubscriptions]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqQuerySubscriptions]
GO
/****** Object:  StoredProcedure [dbo].[iqRoleCreate]    Script Date: 01/25/2007 22:16:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqRoleCreate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqRoleCreate]
GO
/****** Object:  StoredProcedure [dbo].[iqRoleDelete]    Script Date: 01/25/2007 22:16:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqRoleDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqRoleDelete]
GO
/****** Object:  StoredProcedure [dbo].[iqRoleFindAllBySubscription]    Script Date: 01/25/2007 22:16:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqRoleFindAllBySubscription]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqRoleFindAllBySubscription]
GO
/****** Object:  StoredProcedure [dbo].[iqRoleLookup]    Script Date: 01/25/2007 22:16:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqRoleLookup]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqRoleLookup]
GO
/****** Object:  StoredProcedure [dbo].[iqRoleRead]    Script Date: 01/25/2007 22:16:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqRoleRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqRoleRead]
GO
/****** Object:  StoredProcedure [dbo].[iqRoleTemplateCreate]    Script Date: 01/25/2007 22:16:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqRoleTemplateCreate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqRoleTemplateCreate]
GO
/****** Object:  StoredProcedure [dbo].[iqRoleTemplateDelete]    Script Date: 01/25/2007 22:16:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqRoleTemplateDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqRoleTemplateDelete]
GO
/****** Object:  StoredProcedure [dbo].[iqRoleTemplateDescriptionCreate]    Script Date: 01/25/2007 22:16:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqRoleTemplateDescriptionCreate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqRoleTemplateDescriptionCreate]
GO
/****** Object:  StoredProcedure [dbo].[iqRoleTemplateDescriptionFindAll]    Script Date: 01/25/2007 22:16:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqRoleTemplateDescriptionFindAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqRoleTemplateDescriptionFindAll]
GO
/****** Object:  StoredProcedure [dbo].[iqRoleTemplateDescriptionUpdate]    Script Date: 01/25/2007 22:16:17 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqRoleTemplateDescriptionUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqRoleTemplateDescriptionUpdate]
GO
/****** Object:  StoredProcedure [dbo].[iqRoleTemplateFindAllByService]    Script Date: 01/25/2007 22:16:17 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqRoleTemplateFindAllByService]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqRoleTemplateFindAllByService]
GO
/****** Object:  StoredProcedure [dbo].[iqRoleTemplateMethodCreate]    Script Date: 01/25/2007 22:16:17 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqRoleTemplateMethodCreate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqRoleTemplateMethodCreate]
GO
/****** Object:  StoredProcedure [dbo].[iqRoleTemplateMethodDelete]    Script Date: 01/25/2007 22:16:17 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqRoleTemplateMethodDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqRoleTemplateMethodDelete]
GO
/****** Object:  StoredProcedure [dbo].[iqRoleTemplateMethodFindAll]    Script Date: 01/25/2007 22:16:17 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqRoleTemplateMethodFindAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqRoleTemplateMethodFindAll]
GO
/****** Object:  StoredProcedure [dbo].[iqRoleTemplateMethodFindAllByRoleTemplate]    Script Date: 01/25/2007 22:16:18 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqRoleTemplateMethodFindAllByRoleTemplate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqRoleTemplateMethodFindAllByRoleTemplate]
GO
/****** Object:  StoredProcedure [dbo].[iqRoleTemplateMethodRead]    Script Date: 01/25/2007 22:16:18 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqRoleTemplateMethodRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqRoleTemplateMethodRead]
GO
/****** Object:  StoredProcedure [dbo].[iqRoleTemplateMethodUpdate]    Script Date: 01/25/2007 22:16:18 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqRoleTemplateMethodUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqRoleTemplateMethodUpdate]
GO
/****** Object:  StoredProcedure [dbo].[iqRoleTemplateRead]    Script Date: 01/25/2007 22:16:18 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqRoleTemplateRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqRoleTemplateRead]
GO
/****** Object:  StoredProcedure [dbo].[iqRoleTemplateUpdate]    Script Date: 01/25/2007 22:16:18 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqRoleTemplateUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqRoleTemplateUpdate]
GO
/****** Object:  StoredProcedure [dbo].[iqRoleUpdate]    Script Date: 01/25/2007 22:16:18 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqRoleUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqRoleUpdate]
GO
/****** Object:  StoredProcedure [dbo].[iqScopeCreate]    Script Date: 01/25/2007 22:16:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqScopeCreate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqScopeCreate]
GO
/****** Object:  StoredProcedure [dbo].[iqScopeCreateByService]    Script Date: 01/25/2007 22:16:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqScopeCreateByService]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqScopeCreateByService]
GO
/****** Object:  StoredProcedure [dbo].[iqScopeCreateBySubscription]    Script Date: 01/25/2007 22:16:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqScopeCreateBySubscription]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqScopeCreateBySubscription]
GO
/****** Object:  StoredProcedure [dbo].[iqScopeDelete]    Script Date: 01/25/2007 22:16:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqScopeDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqScopeDelete]
GO
/****** Object:  StoredProcedure [dbo].[iqScopeFindAllByService]    Script Date: 01/25/2007 22:16:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqScopeFindAllByService]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqScopeFindAllByService]
GO
/****** Object:  StoredProcedure [dbo].[iqScopeFindAllBySubscription]    Script Date: 01/25/2007 22:16:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqScopeFindAllBySubscription]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqScopeFindAllBySubscription]
GO
/****** Object:  StoredProcedure [dbo].[iqScopeLookupByMethodType]    Script Date: 01/25/2007 22:16:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqScopeLookupByMethodType]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqScopeLookupByMethodType]
GO
/****** Object:  StoredProcedure [dbo].[iqScopeRead]    Script Date: 01/25/2007 22:16:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqScopeRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqScopeRead]
GO
/****** Object:  StoredProcedure [dbo].[iqScopeUpdate]    Script Date: 01/25/2007 22:16:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqScopeUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqScopeUpdate]
GO
/****** Object:  StoredProcedure [dbo].[iqServiceChargeCreate]    Script Date: 01/25/2007 22:16:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqServiceChargeCreate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqServiceChargeCreate]
GO
/****** Object:  StoredProcedure [dbo].[iqServiceChargeDelete]    Script Date: 01/25/2007 22:16:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqServiceChargeDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqServiceChargeDelete]
GO
/****** Object:  StoredProcedure [dbo].[iqServiceChargeFindAllByService]    Script Date: 01/25/2007 22:16:21 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqServiceChargeFindAllByService]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqServiceChargeFindAllByService]
GO
/****** Object:  StoredProcedure [dbo].[iqServiceChargeRead]    Script Date: 01/25/2007 22:16:21 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqServiceChargeRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqServiceChargeRead]
GO
/****** Object:  StoredProcedure [dbo].[iqServiceChargeUpdate]    Script Date: 01/25/2007 22:16:21 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqServiceChargeUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqServiceChargeUpdate]
GO
/****** Object:  StoredProcedure [dbo].[iqServiceCreate]    Script Date: 01/25/2007 22:16:21 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqServiceCreate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqServiceCreate]
GO
/****** Object:  StoredProcedure [dbo].[iqServiceDelete]    Script Date: 01/25/2007 22:16:21 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqServiceDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqServiceDelete]
GO
/****** Object:  StoredProcedure [dbo].[iqServiceFindAllByAuthor]    Script Date: 01/25/2007 22:16:22 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqServiceFindAllByAuthor]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqServiceFindAllByAuthor]
GO
/****** Object:  StoredProcedure [dbo].[iqServiceFindByAuthor]    Script Date: 01/25/2007 22:16:22 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqServiceFindByAuthor]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqServiceFindByAuthor]
GO
/****** Object:  StoredProcedure [dbo].[iqServiceFindByName]    Script Date: 01/25/2007 22:16:22 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqServiceFindByName]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqServiceFindByName]
GO
/****** Object:  StoredProcedure [dbo].[iqServiceMethodCreate]    Script Date: 01/25/2007 22:16:22 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqServiceMethodCreate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqServiceMethodCreate]
GO
/****** Object:  StoredProcedure [dbo].[iqServiceMethodDelete]    Script Date: 01/25/2007 22:16:22 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqServiceMethodDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqServiceMethodDelete]
GO
/****** Object:  StoredProcedure [dbo].[iqServiceMethodFindByName]    Script Date: 01/25/2007 22:16:22 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqServiceMethodFindByName]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqServiceMethodFindByName]
GO
/****** Object:  StoredProcedure [dbo].[iqServiceMethodRead]    Script Date: 01/25/2007 22:16:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqServiceMethodRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqServiceMethodRead]
GO
/****** Object:  StoredProcedure [dbo].[iqServiceMethodUpdate]    Script Date: 01/25/2007 22:16:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqServiceMethodUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqServiceMethodUpdate]
GO
/****** Object:  StoredProcedure [dbo].[iqServiceRead]    Script Date: 01/25/2007 22:16:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqServiceRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqServiceRead]
GO
/****** Object:  StoredProcedure [dbo].[iqServiceScopeCreate]    Script Date: 01/25/2007 22:16:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqServiceScopeCreate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqServiceScopeCreate]
GO
/****** Object:  StoredProcedure [dbo].[iqServiceScopeDelete]    Script Date: 01/25/2007 22:16:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqServiceScopeDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqServiceScopeDelete]
GO
/****** Object:  StoredProcedure [dbo].[iqServiceUpdate]    Script Date: 01/25/2007 22:16:24 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqServiceUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqServiceUpdate]
GO
/****** Object:  StoredProcedure [dbo].[iqShapeCreate]    Script Date: 01/25/2007 22:16:24 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqShapeCreate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqShapeCreate]
GO
/****** Object:  StoredProcedure [dbo].[iqShapeDelete]    Script Date: 01/25/2007 22:16:24 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqShapeDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqShapeDelete]
GO
/****** Object:  StoredProcedure [dbo].[iqShapeFindAllByScope]    Script Date: 01/25/2007 22:16:24 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqShapeFindAllByScope]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqShapeFindAllByScope]
GO
/****** Object:  StoredProcedure [dbo].[iqShapeRead]    Script Date: 01/25/2007 22:16:24 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqShapeRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqShapeRead]
GO
/****** Object:  StoredProcedure [dbo].[iqShapeUpdate]    Script Date: 01/25/2007 22:16:24 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqShapeUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqShapeUpdate]
GO
/****** Object:  StoredProcedure [dbo].[iqSubscriptionCreate]    Script Date: 01/25/2007 22:16:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqSubscriptionCreate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqSubscriptionCreate]
GO
/****** Object:  StoredProcedure [dbo].[iqSubscriptionDelete]    Script Date: 01/25/2007 22:16:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqSubscriptionDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqSubscriptionDelete]
GO
/****** Object:  StoredProcedure [dbo].[iqSubscriptionFindAllByUrlXml]    Script Date: 01/25/2007 22:16:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqSubscriptionFindAllByUrlXml]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqSubscriptionFindAllByUrlXml]
GO
/****** Object:  StoredProcedure [dbo].[iqSubscriptionFindByAccountIdName]    Script Date: 01/25/2007 22:16:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqSubscriptionFindByAccountIdName]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqSubscriptionFindByAccountIdName]
GO
/****** Object:  StoredProcedure [dbo].[iqSubscriptionListenerCreate]    Script Date: 01/25/2007 22:16:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqSubscriptionListenerCreate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqSubscriptionListenerCreate]
GO
/****** Object:  StoredProcedure [dbo].[iqSubscriptionListenerDelete]    Script Date: 01/25/2007 22:16:26 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqSubscriptionListenerDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqSubscriptionListenerDelete]
GO
/****** Object:  StoredProcedure [dbo].[iqSubscriptionListenerFindAllBySubscription]    Script Date: 01/25/2007 22:16:26 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqSubscriptionListenerFindAllBySubscription]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqSubscriptionListenerFindAllBySubscription]
GO
/****** Object:  StoredProcedure [dbo].[iqSubscriptionListenerRead]    Script Date: 01/25/2007 22:16:26 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqSubscriptionListenerRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqSubscriptionListenerRead]
GO
/****** Object:  StoredProcedure [dbo].[iqSubscriptionListenerUpdate]    Script Date: 01/25/2007 22:16:26 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqSubscriptionListenerUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqSubscriptionListenerUpdate]
GO
/****** Object:  StoredProcedure [dbo].[iqSubscriptionRead]    Script Date: 01/25/2007 22:16:26 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqSubscriptionRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqSubscriptionRead]
GO
/****** Object:  StoredProcedure [dbo].[iqSubscriptionScopeCreate]    Script Date: 01/25/2007 22:16:26 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqSubscriptionScopeCreate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqSubscriptionScopeCreate]
GO
/****** Object:  StoredProcedure [dbo].[iqSubscriptionScopeDelete]    Script Date: 01/25/2007 22:16:27 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqSubscriptionScopeDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqSubscriptionScopeDelete]
GO
/****** Object:  StoredProcedure [dbo].[iqSubscriptionScopeFindAllBySubscription]    Script Date: 01/25/2007 22:16:27 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqSubscriptionScopeFindAllBySubscription]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqSubscriptionScopeFindAllBySubscription]
GO
/****** Object:  StoredProcedure [dbo].[iqSubscriptionServices]    Script Date: 01/25/2007 22:16:27 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqSubscriptionServices]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqSubscriptionServices]
GO
/****** Object:  StoredProcedure [dbo].[iqSubscriptionUpdate]    Script Date: 01/25/2007 22:16:27 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqSubscriptionUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[iqSubscriptionUpdate]
GO
/****** Object:  StoredProcedure [dbo].[GetSubscription]    Script Date: 01/25/2007 22:16:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetSubscription]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--
-- FIXME is this being used?
--
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
	url_xml,
	role_list
	
FROM
	subscription
	
WHERE
	account_id = @account_id AND
	service_id = @service_id
' 
END
GO
/****** Object:  StoredProcedure [dbo].[LogAction]    Script Date: 01/25/2007 22:16:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LogAction]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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
' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqAccountCreate]    Script Date: 01/25/2007 22:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqAccountCreate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--
--
--
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


' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqAccountDelete]    Script Date: 01/25/2007 22:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqAccountDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE dbo.iqDeleteAccount (
	@id int
)

AS

DELETE FROM
	account
	
WHERE
	id = @id
' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqAccountFindByEmailPassword]    Script Date: 01/25/2007 22:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqAccountFindByEmailPassword]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqAccountFindByIqid]    Script Date: 01/25/2007 22:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqAccountFindByIqid]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqAccountFindByToken]    Script Date: 01/25/2007 22:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqAccountFindByToken]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE dbo.iqFindAccountByToken (
	@token char(40)
)

AS

SELECT
	a.id,
	a.owner_account_id,
	a.group_id,
	a.iqid,
	a.email,
	a.password
	
FROM
	account a,
	token t
	
WHERE
	token = @token
AND
	a.id = t.account_id

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqAccountRead]    Script Date: 01/25/2007 22:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqAccountRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqAccountUpdate]    Script Date: 01/25/2007 22:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqAccountUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqAuthorCreate]    Script Date: 01/25/2007 22:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqAuthorCreate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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


' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqAuthorDelete]    Script Date: 01/25/2007 22:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqAuthorDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE dbo.iqDeleteAuthor (
	@id int
)

AS

DELETE FROM
	author
	
WHERE
	id = @id
' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqAuthorFindAllPackages]    Script Date: 01/25/2007 22:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqAuthorFindAllPackages]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqAuthorLookup]    Script Date: 01/25/2007 22:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqAuthorLookup]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqChargeUnitFindAll]    Script Date: 01/25/2007 22:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqChargeUnitFindAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqDeleteLogCreate]    Script Date: 01/25/2007 22:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqDeleteLogCreate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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
' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqDeleteLogDelete]    Script Date: 01/25/2007 22:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqDeleteLogDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE dbo.iqDeleteDeleteLog (
	@subscription_id uniqueidentifier,
	@change_number int,
	@uuid varchar(40)
)

AS

DELETE FROM
	delete_log
	
WHERE
	subscription_id = @subscription_id
AND
	change_number = @change_number
AND
	uuid = @uuid

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqDeleteLogFindAll]    Script Date: 01/25/2007 22:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqDeleteLogFindAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqFindLatestPackage]    Script Date: 01/25/2007 22:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqFindLatestPackage]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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
	p.state = ''A''
	
ORDER BY
	p.release_date DESC
' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqFindPackage]    Script Date: 01/25/2007 22:16:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqFindPackage]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE dbo.iqFindPackage (
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
' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqFindSubscriptionByAccountService]    Script Date: 01/25/2007 22:16:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqFindSubscriptionByAccountService]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE dbo.iqFindSubscriptionByAccountService (
	@account_id int,
	@service_id int
)

AS

SELECT
	id,
	account_id,
	service_id,
	[xml]
	
FROM
	subscription
	
WHERE
	account_id = @account_id AND
	service_id = @service_id' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqListAllLanguages]    Script Date: 01/25/2007 22:16:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqListAllLanguages]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE dbo.iqListAllLanguages

AS

SELECT
	id				AS Id,
	[name]			AS Name
	
FROM
	language
	
ORDER BY
	[name]

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqListAllRoleTemplateMethods]    Script Date: 01/25/2007 22:16:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqListAllRoleTemplateMethods]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqListAllRoleTemplatesByService]    Script Date: 01/25/2007 22:16:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqListAllRoleTemplatesByService]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqListAllScopesByService]    Script Date: 01/25/2007 22:16:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqListAllScopesByService]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
--
-- Fetches list of scopes defined for a given service.
--
CREATE PROCEDURE dbo.iqListAllScopesByService
	@service_id int,
	@language_id int
AS

SELECT
	ss.service_id							AS ServiceId,
	s.id									AS ScopeId,
	s.[name]								AS ScopeName,
	s.base									AS ScopeBase,
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
	
' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqListAllScopesBySubscription]    Script Date: 01/25/2007 22:16:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqListAllScopesBySubscription]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



--
-- 
--
CREATE PROCEDURE [dbo].[iqListAllScopesBySubscription]
	@subscription_id uniqueidentifier,
	@language_id int
AS


SELECT 
	ss.subscription_id						AS SubscriptionId,
	s.id									AS ScopeId,
	s.[name]								AS ScopeName,
	s.base									AS ScopeBase,
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

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqListAllScopesForSubscription]    Script Date: 01/25/2007 22:16:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqListAllScopesForSubscription]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
--
-- Returns union of scopes for service and subscription
--
CREATE PROCEDURE dbo.iqListAllScopesForSubscription
	@subscription_id uniqueidentifier,
	@language_id int
AS

SELECT DISTINCT
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
	
WHERE (
	sers.scope_id = s.id
OR
	subs.scope_id = s.id
)
AND
	sers.service_id = sub.service_id
AND
	sub.id = @subscription_id

ORDER BY
	s.[name]
' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqListAllServiceChargesByService]    Script Date: 01/25/2007 22:16:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqListAllServiceChargesByService]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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


' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqListAllServiceMethodsByService]    Script Date: 01/25/2007 22:16:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqListAllServiceMethodsByService]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- 
-- 
-- 
CREATE PROCEDURE dbo.iqListAllServiceMethodsByService
	@service_id int
AS

SELECT 
	sm.id				AS ServiceMethodId,
	service_id			AS ServiceId, 
	sm.name				AS ServiceMethodName,
	method_type_id		AS MethodTypeId, 
	script				AS Script,
	script_url			AS ScriptUrl,
	mt.name				AS MethodTypeName
	
FROM
	service_method sm,
	method_type mt
	
WHERE 
	service_id = @service_id
AND
	mt.id = method_type_id
' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqListAllServicesByAuthorId]    Script Date: 01/25/2007 22:16:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqListAllServicesByAuthorId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--
--
--
CREATE PROCEDURE dbo.iqListAllServicesByAuthorId (
	@author_id int,
	@language_id int
)

AS

SELECT 
	se.id						AS ServiceId, 
	author_id					AS ServiceAuthorId, 
	[name]						AS ServiceName, 
	version						AS ServiceVersion, 
	url_icon					AS ServiceUrlIcon, 
	url_homepage				AS ServiceUrlHomepage, 
	state						AS ServiceState,
	sd.short_description		AS ServiceShortDescription,
	dbo.iqFindSubscriptionCountByService(se.id)
								AS SubscriptionCount

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
	[name] ASC

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqListListenersBySubscription]    Script Date: 01/25/2007 22:16:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqListListenersBySubscription]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqListMySubscriptions]    Script Date: 01/25/2007 22:16:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqListMySubscriptions]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE dbo.iqListMySubscriptions (
	@account_id int,
	@language_id int
)

AS

SELECT
	su.id					AS SubscriptionId,
	su.name					AS SubscriptionName,
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
	se.state = ''P''

ORDER BY
	SubscriptionName, 
	ServiceName, 
	ServiceVersion
' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqListProvisionedServices]    Script Date: 01/25/2007 22:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqListProvisionedServices]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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
	se.state = ''P''

ORDER BY
	ServiceName, ServiceVersion, AuthorName
' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqListRolesBySubscription]    Script Date: 01/25/2007 22:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqListRolesBySubscription]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqListServiceScopes]    Script Date: 01/25/2007 22:16:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqListServiceScopes]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqMethodHistoryCreate]    Script Date: 01/25/2007 22:16:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqMethodHistoryCreate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
--
-- Tracks incoming requests
-- 
-- <insertRequest service="myBookmarks" select="//folder[title=''Daily Use'']" >
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
	@method nvarchar(64),
	@user_host_address nvarchar(64)
)

AS

INSERT INTO method_history (
	account_id,
	subscription_id, 
	[timestamp], 
	method,
	user_host_address
)
VALUES (
	@account_id,
	@subscription_id,
	CURRENT_TIMESTAMP,
	@method,
	@user_host_address
)

SELECT id FROM method_history WHERE id = @@IDENTITY
' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqMethodHistoryFindAll]    Script Date: 01/25/2007 22:16:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqMethodHistoryFindAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--
--
--
CREATE PROCEDURE dbo.iqFindAllMethodHistories (
	@account_id int,
	@language_id int
)

AS

SELECT
	mh.id							AS MethodHistoryId,
	mh.account_id					AS MethodHistoryAccountId,
	mh.subscription_id				AS MethodHistorySubscriptionId,
	mh.[timestamp]					AS MethodHistoryTimestamp,
	mh.method						AS MethodHistoryMethod,
	mh.user_host_address			AS MethodHistoryUserHostAddress,
	s.id							AS ServiceId,
	s.name							AS ServiceName,
	s.version						AS ServiceVersion,
	s.url_icon						AS ServiceUrlIcon,
	sd.short_description			AS ServiceShortDescription,
	sub.name						AS SubscriptionName,
	a.iqid							AS AccountIqid,
	a.email							AS AccountEmail

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
' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqMethodTypeFindAll]    Script Date: 01/25/2007 22:16:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqMethodTypeFindAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqMethodTypeRead]    Script Date: 01/25/2007 22:16:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqMethodTypeRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqPackageCreate]    Script Date: 01/25/2007 22:16:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqPackageCreate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE dbo.iqPackageCreate (
	@service_id int,
	@platform_id int,
	@version nvarchar(16),
	@release_date datetime,
	@state char(1)
)

AS
	
INSERT INTO package (
	service_id, 
	platform_id,
	version, 
	release_date, 
	state
) VALUES (
	@service_id,
	@platform_id, 
	@version, 
	@release_date, 
	@state
)

SELECT id FROM package WHERE id = @@IDENTITY


' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqPackageDelete]    Script Date: 01/25/2007 22:16:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqPackageDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE dbo.iqPackageDelete (
	@id int
)

AS

DELETE FROM
	package
	
WHERE
	id = @id

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqPackageFindAllByAuthor]    Script Date: 01/25/2007 22:16:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqPackageFindAllByAuthor]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE dbo.iqPackageFindAllByAuthor (
	@author_id int,
	@language_id int
)

AS

SELECT
	s.id				AS ServiceId,
	s.[name]			AS ServiceName,
	s.url_icon			AS ServiceUrlIcon,
	s.url_homepage		AS ServiceUrlHomepage,
	pl.name				AS PackagePlatformName,
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
	platform pl,
	service s

WHERE
	p.service_id = s.id
AND
	s.author_id = @author_id
AND
	pl.id = p.platform_id
AND
	pl.language_id = @language_id

GROUP BY
	s.id, s.[name], s.url_icon, s.url_homepage, pl.name, p.id, p.version, p.release_date, p.state

ORDER BY
	s.[name]

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqPackageItemCreate]    Script Date: 01/25/2007 22:16:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqPackageItemCreate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE dbo.iqPackageItemCreate (
	@package_id int,
	@name nvarchar(128),
	@type nvarchar(128),
	@size bigint,
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
' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqPackageItemDelete]    Script Date: 01/25/2007 22:16:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqPackageItemDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE dbo.iqDeletePackageItem (
	@id int
)

AS

DELETE FROM
	package_item
	
WHERE
	id = @id

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqPackageItemFindAll]    Script Date: 01/25/2007 22:16:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqPackageItemFindAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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
' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqPackageItemFindAllPartial]    Script Date: 01/25/2007 22:16:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqPackageItemFindAllPartial]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqPackageItemRead]    Script Date: 01/25/2007 22:16:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqPackageItemRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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
' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqPackageItemUpdate]    Script Date: 01/25/2007 22:16:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqPackageItemUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE dbo.iqPackageItemUpdate (
	@id int,
	@package_id int,
	@name nvarchar(128),
	@type nvarchar(128),
	@size bigint,
	@data image	
)

AS

IF (@size = 0) BEGIN
	SET @size = DATALENGTH(@data)
END

UPDATE
	package_item
	
SET
	package_id = @package_id,
	[name] = @name,
	type = @type,
	[size] = @size,
	data = @data
	
WHERE
	id = @id
	' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqPackageRead]    Script Date: 01/25/2007 22:16:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqPackageRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE dbo.iqPackageRead (
	@id int
)

AS

SELECT
	id,
	service_id,
	platform_id,
	version,
	release_date,
	state
	
FROM
	package

WHERE
	id = @id

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqPackageUpdate]    Script Date: 01/25/2007 22:16:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqPackageUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE dbo.iqPackageUpdate (
	@id int,
	@service_id int,
	@platform_id int,
	@version nvarchar(16),
	@release_date datetime,
	@state char(1)
)

AS

UPDATE
	package

SET
	service_id = @service_id, 
	platform_id = @platform_id,
	version = @version, 
	release_date = @release_date, 
	state = @state

WHERE
	id = @id

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqPlatformFindAll]    Script Date: 01/25/2007 22:16:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqPlatformFindAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE dbo.iqPlatformFindAll (
	@language_id int
)

AS

SELECT 
	*
	
FROM 
	platform
	
WHERE 
	language_id = @language_ID 

ORDER BY
	[name]

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqQuerySubscriptions]    Script Date: 01/25/2007 22:16:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqQuerySubscriptions]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--
--
--
CREATE PROCEDURE dbo.iqQuerySubscriptions (
	@account_id int,
	@language_id int,
	@query nvarchar(1024)
)

AS

SELECT
	s.id						AS ServiceId,
	s.[name]					AS ServiceName,
	s.version					AS ServiceVersion,
	s.url_icon					AS ServiceUrlIcon,
	sd.short_description		AS ServiceShortDescription,
	su.id						AS SubscriptionId,
	su.[name]					AS SubscriptionName,
	a.[name]					AS AuthorName,
	kt.rank						AS Rank	

FROM 
	service s LEFT OUTER JOIN service_description sd ON s.id = sd.service_id,
	author a,
	subscription su INNER JOIN
	CONTAINSTABLE(subscription, [xml], @query) AS kt ON su.id = kt.[key]
	
WHERE
	a.id = s.author_id
AND
	su.account_id = @account_id
AND
	s.id = su.service_id
AND
	CONTAINS([xml], @query)

ORDER BY
	kt.rank DESC,
	su.name ASC
' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqRoleCreate]    Script Date: 01/25/2007 22:16:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqRoleCreate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqRoleDelete]    Script Date: 01/25/2007 22:16:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqRoleDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE dbo.iqDeleteRole (
	@id int
)

AS

DELETE FROM
	role
	
WHERE
	id = @id
' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqRoleFindAllBySubscription]    Script Date: 01/25/2007 22:16:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqRoleFindAllBySubscription]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqRoleLookup]    Script Date: 01/25/2007 22:16:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqRoleLookup]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqRoleRead]    Script Date: 01/25/2007 22:16:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqRoleRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqRoleTemplateCreate]    Script Date: 01/25/2007 22:16:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqRoleTemplateCreate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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
' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqRoleTemplateDelete]    Script Date: 01/25/2007 22:16:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqRoleTemplateDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE dbo.iqDeleteRoleTemplate (
	@id int
)

AS

DELETE FROM
	role_template
	
WHERE
	id = @id

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqRoleTemplateDescriptionCreate]    Script Date: 01/25/2007 22:16:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqRoleTemplateDescriptionCreate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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


' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqRoleTemplateDescriptionFindAll]    Script Date: 01/25/2007 22:16:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqRoleTemplateDescriptionFindAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqRoleTemplateDescriptionUpdate]    Script Date: 01/25/2007 22:16:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqRoleTemplateDescriptionUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqRoleTemplateFindAllByService]    Script Date: 01/25/2007 22:16:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqRoleTemplateFindAllByService]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqRoleTemplateMethodCreate]    Script Date: 01/25/2007 22:16:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqRoleTemplateMethodCreate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqRoleTemplateMethodDelete]    Script Date: 01/25/2007 22:16:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqRoleTemplateMethodDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqRoleTemplateMethodFindAll]    Script Date: 01/25/2007 22:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqRoleTemplateMethodFindAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqRoleTemplateMethodFindAllByRoleTemplate]    Script Date: 01/25/2007 22:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqRoleTemplateMethodFindAllByRoleTemplate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqRoleTemplateMethodRead]    Script Date: 01/25/2007 22:16:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqRoleTemplateMethodRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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
' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqRoleTemplateMethodUpdate]    Script Date: 01/25/2007 22:16:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqRoleTemplateMethodUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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
' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqRoleTemplateRead]    Script Date: 01/25/2007 22:16:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqRoleTemplateRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqRoleTemplateUpdate]    Script Date: 01/25/2007 22:17:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqRoleTemplateUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqRoleUpdate]    Script Date: 01/25/2007 22:17:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqRoleUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqScopeCreate]    Script Date: 01/25/2007 22:17:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqScopeCreate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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
' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqScopeCreateByService]    Script Date: 01/25/2007 22:17:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqScopeCreateByService]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqScopeCreateBySubscription]    Script Date: 01/25/2007 22:17:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqScopeCreateBySubscription]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE dbo.iqScopeCreateBySubscription (
	@subscription_id uniqueidentifier,
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

-- insert relation between new scope and existing subscription
EXEC iqSubscriptionScopeCreate @subscription_id, @scope_id

-- do _not_ use RETURN since code always requires data sets (for more
-- generic handling)
SELECT @scope_id

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqScopeDelete]    Script Date: 01/25/2007 22:17:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqScopeDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE dbo.iqDeleteScope (
	@id int
)

AS

DELETE FROM
	scope
	
WHERE
	id = @id

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqScopeFindAllByService]    Script Date: 01/25/2007 22:17:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqScopeFindAllByService]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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
	

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqScopeFindAllBySubscription]    Script Date: 01/25/2007 22:17:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqScopeFindAllBySubscription]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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
	
' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqScopeLookupByMethodType]    Script Date: 01/25/2007 22:17:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqScopeLookupByMethodType]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqScopeRead]    Script Date: 01/25/2007 22:17:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqScopeRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqScopeUpdate]    Script Date: 01/25/2007 22:17:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqScopeUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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
' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqServiceChargeCreate]    Script Date: 01/25/2007 22:17:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqServiceChargeCreate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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
' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqServiceChargeDelete]    Script Date: 01/25/2007 22:17:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqServiceChargeDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE dbo.iqDeleteServiceCharge (
	@id int
)

AS

DELETE FROM
	service_charge
	
WHERE
	id = @id
' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqServiceChargeFindAllByService]    Script Date: 01/25/2007 22:17:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqServiceChargeFindAllByService]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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


' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqServiceChargeRead]    Script Date: 01/25/2007 22:17:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqServiceChargeRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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
' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqServiceChargeUpdate]    Script Date: 01/25/2007 22:17:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqServiceChargeUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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
' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqServiceCreate]    Script Date: 01/25/2007 22:17:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqServiceCreate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE dbo.iqCreateService (
	@author_id int,
	@name nvarchar(64),
	@version nvarchar(16),
	@xsd text,
	@url_xsd nvarchar(320),
	@url_icon nvarchar(128),
	@url_homepage nvarchar(128),
	@state char(1) = ''D'',
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

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqServiceDelete]    Script Date: 01/25/2007 22:17:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqServiceDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE dbo.iqDeleteService (
	@id int
)

AS

DELETE FROM
	service
	
WHERE
	id = @id

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqServiceFindAllByAuthor]    Script Date: 01/25/2007 22:17:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqServiceFindAllByAuthor]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqServiceFindByAuthor]    Script Date: 01/25/2007 22:17:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqServiceFindByAuthor]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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
' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqServiceFindByName]    Script Date: 01/25/2007 22:17:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqServiceFindByName]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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
' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqServiceMethodCreate]    Script Date: 01/25/2007 22:17:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqServiceMethodCreate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--
-- 
--
CREATE PROCEDURE dbo.iqCreateServiceMethod (
	@service_id int,
	@method_type_id int,
	@name nvarchar(64),
	@select nvarchar(64),
	@script text = NULL,
	@script_url nvarchar(128) = NULL
)

AS

INSERT INTO service_method (
	service_id,
	method_type_id,
	[name],
	[select],
	script,
	script_url
)
VALUES (
	@service_id,
	@method_type_id,
	@name,
	@select,
	@script,
	@script_url
)

SELECT id FROM service_method WHERE id = @@IDENTITY
' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqServiceMethodDelete]    Script Date: 01/25/2007 22:17:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqServiceMethodDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--
--
--
CREATE PROCEDURE dbo.iqDeleteServiceMethod (
	@id int
)

AS

DELETE FROM
	service_method
	
WHERE
	id = @id
' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqServiceMethodFindByName]    Script Date: 01/25/2007 22:17:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqServiceMethodFindByName]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE dbo.iqFindServiceMethodByName (
	@service_id int,
	@name nvarchar(64)
)

AS

SELECT
	id,
	service_id,
	[name],
	[select],
	method_type_id,
	script,
	script_url
	
FROM
	service_method
	
WHERE
	service_id = @service_id
AND
	[name] = @name
	
' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqServiceMethodRead]    Script Date: 01/25/2007 22:17:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqServiceMethodRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--
--
--
CREATE PROCEDURE dbo.iqReadServiceMethod (
	@id int
)

AS

SELECT
	id,
	service_id,
	[name],
	[select],
	method_type_id,
	script,
	script_url
	
FROM
	service_method
	
WHERE
	id = @id
' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqServiceMethodUpdate]    Script Date: 01/25/2007 22:17:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqServiceMethodUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--
--
--
CREATE PROCEDURE dbo.iqUpdateServiceMethod (
	@id int,
	@service_id int,
	@name nvarchar(64),
	@select nvarchar(64),
	@method_type_id int,
	@script text = NULL,
	@script_url nvarchar(128) = NULL
)

AS

UPDATE
	service_method

SET
	service_id = @service_id,
	[name] = @name,
	[select] = @select,
	method_type_id = @method_type_id,
	script = @script,
	script_url = @script_url

WHERE
	id = @id
' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqServiceRead]    Script Date: 01/25/2007 22:17:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqServiceRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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
' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqServiceScopeCreate]    Script Date: 01/25/2007 22:17:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqServiceScopeCreate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqServiceScopeDelete]    Script Date: 01/25/2007 22:17:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqServiceScopeDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqServiceUpdate]    Script Date: 01/25/2007 22:17:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqServiceUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqShapeCreate]    Script Date: 01/25/2007 22:17:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqShapeCreate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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
' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqShapeDelete]    Script Date: 01/25/2007 22:17:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqShapeDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE dbo.iqDeleteShape (
	@id int
)

AS

DELETE FROM
	shape
	
WHERE
	id = @id

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqShapeFindAllByScope]    Script Date: 01/25/2007 22:17:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqShapeFindAllByScope]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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
' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqShapeRead]    Script Date: 01/25/2007 22:17:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqShapeRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqShapeUpdate]    Script Date: 01/25/2007 22:17:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqShapeUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqSubscriptionCreate]    Script Date: 01/25/2007 22:17:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqSubscriptionCreate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
--
-- Creates new subscription
--
CREATE PROCEDURE dbo.iqCreateSubscription (
	@id uniqueidentifier,
	@account_id int,
	@service_id int,
	@name nvarchar(64),
	@xml text,
	@url_xml nvarchar(160),
	@role_list text,
	@notify_list text
)

AS

INSERT INTO subscription (
	id,
	account_id,
	service_id,
	[name],
	[xml],
	url_xml,
	role_list,
	notify_list
)
VALUES (
	@id,
	@account_id,
	@service_id,
	@name,
	@xml,
	@url_xml,
	@role_list,
	@notify_list
)
' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqSubscriptionDelete]    Script Date: 01/25/2007 22:17:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqSubscriptionDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- 
-- 
-- 
CREATE PROCEDURE dbo.iqDeleteSubscription (
	@id uniqueidentifier,
	@account_id int
)

AS

-- [TO-DO] We need to log this delete request so it''s possible to charge 
-- user for the entire period (if selected)

DELETE FROM
	subscription
	
WHERE
	id = @id
AND
	account_id = @account_id
' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqSubscriptionFindAllByUrlXml]    Script Date: 01/25/2007 22:17:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqSubscriptionFindAllByUrlXml]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE dbo.iqFindAllSubscriptionsByUrlXml (
	@url_xml nvarchar(160)
)

AS

SELECT 
	*
	
FROM 
	subscription
	
WHERE 
	url_xml = @url_xml
' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqSubscriptionFindByAccountIdName]    Script Date: 01/25/2007 22:17:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqSubscriptionFindByAccountIdName]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- 
-- 
-- 
CREATE PROCEDURE dbo.iqFindSubscriptionByAccountIdName (
	@account_id int,
	@name nvarchar(64)
)

AS

SELECT
	id,
	account_id,
	service_id,
	[name],
	[xml],
	url_xml,
	role_list,
	notify_list
	
FROM
	subscription
	
WHERE
	account_id = @account_id
AND
	[name] = @name
' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqSubscriptionListenerCreate]    Script Date: 01/25/2007 22:17:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqSubscriptionListenerCreate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqSubscriptionListenerDelete]    Script Date: 01/25/2007 22:17:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqSubscriptionListenerDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE dbo.iqDeleteSubscriptionListener (
	@id int
)

AS

DELETE FROM
	subscription_listener
	
WHERE
	id = @id
' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqSubscriptionListenerFindAllBySubscription]    Script Date: 01/25/2007 22:17:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqSubscriptionListenerFindAllBySubscription]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqSubscriptionListenerRead]    Script Date: 01/25/2007 22:17:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqSubscriptionListenerRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqSubscriptionListenerUpdate]    Script Date: 01/25/2007 22:17:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqSubscriptionListenerUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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
' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqSubscriptionRead]    Script Date: 01/25/2007 22:17:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqSubscriptionRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE dbo.iqReadSubscription (
	@id uniqueidentifier
)

AS

SELECT
	id,
	account_id,
	service_id,
	[name],
	[xml],
	url_xml,
	role_list,
	notify_list
	
FROM
	subscription
	
WHERE
	id = @id

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqSubscriptionScopeCreate]    Script Date: 01/25/2007 22:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqSubscriptionScopeCreate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqSubscriptionScopeDelete]    Script Date: 01/25/2007 22:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqSubscriptionScopeDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqSubscriptionScopeFindAllBySubscription]    Script Date: 01/25/2007 22:17:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqSubscriptionScopeFindAllBySubscription]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE dbo.iqSubscriptionScopeFindAllBySubscription
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
	ss.scope_id = s.id' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqSubscriptionServices]    Script Date: 01/25/2007 22:17:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqSubscriptionServices]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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

' 
END
GO
/****** Object:  StoredProcedure [dbo].[iqSubscriptionUpdate]    Script Date: 01/25/2007 22:17:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[iqSubscriptionUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE dbo.iqUpdateSubscription (
	@id uniqueidentifier,
	@account_id int,
	@name nvarchar(64),
	@xml text,
	@url_xml nvarchar(160),
	@role_list text,
	@notify_list text
)

AS

UPDATE
	subscription

SET
	[name] = @name,
	[xml] = @xml,
	url_xml = @url_xml,
	role_list = @role_list,
	notify_list = @notify_list

WHERE
	id = @id
AND
	account_id = @account_id
' 
END
GO
