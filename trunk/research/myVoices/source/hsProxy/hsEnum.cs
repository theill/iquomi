using System;

namespace hsProxy
{
	public enum hsServices
	{
		myAlerts,
		myApplicationSettings,
		myCalendar,
		myCategories,
		myContacts,
		myDevices,
		myFavoriteWebSites,
		myLists,
		myLocation,
		myPresence,
		myProfile,
		myServices,
		myWallet
	}

	public enum hsDocuments
	{
		content,
		roleList,
		system
		//, admin?
	}

	public enum hsOperations
	{
		insert,
		query,
		replace,
		delete,
		update,
		subscription
	}
}
