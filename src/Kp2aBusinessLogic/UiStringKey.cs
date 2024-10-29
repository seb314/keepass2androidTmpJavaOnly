namespace keepass2android
{
	/// <summary>
	/// Keys to identify user-displayable strings.
	/// </summary>
	/// Do not rename the keys here unless you rename the corresponding keys in the resource file of KP2A.
	/// The keys are resolved by reflection to the static Resource class. This kind of duplication is necessary 
	/// in order to use the Resource mechanism of Android but still decouple the logic layer from the UI.
    public enum UiStringKey
    {
        AskDeletePermanentlyGroup,
		AskDeletePermanentlyGroupNoRecycle,
        progress_title,
        AskDeletePermanentlyEntry,
		AskDeletePermanentlyEntryNoRecycle,
        search_results,
        AskDeletePermanently_title,
        saving_database,
        keyfile_does_not_exist,
        RecycleBin,
        progress_create,
        loading_database,
		AddingEntry,
		AddingGroup,
		DeletingEntry,
		DeletingGroup,
		SettingPassword,
		UndoingChanges,
		TransformingKey,
		DecodingDatabase,
		ParsingDatabase,
		CheckingTargetFileForChanges,
		TitleSyncQuestion,
		MessageSyncQuestion,
		SynchronizingDatabase,
		yes,
		no,
		YesSynchronize, 
		NoOverwrite,
		SynchronizingCachedDatabase,
		DownloadingRemoteFile,
		UploadingFile,
		FilesInSync,
		SynchronizedDatabaseSuccessfully,
		RestoringRemoteFile,
		CheckingDatabaseForChanges,
		RemoteDatabaseUnchanged,
		CannotMoveGroupHere,
		ErrorOcurred,
		SynchronizingOtpAuxFile,
		SavingOtpAuxFile,
		CertificateFailure,
		exporting_database,
		FileIsTemporarilyAvailable,
		CopyFileRequired,
		ClickOkToSelectLocation,
		FileIsReadOnly,
		FileIsReadOnlyOnKitkat,
		CopyFileRequiredForEditing,
		DuplicateUuidsError,
		DuplicateUuidsErrorAdditional,
		DeletingItems,
		AskDeletePermanentlyItems,
		AskDeletePermanentlyItemsNoRecycle,
		InOfflineMode,
        DocumentAccessRevoked,
        DuplicateTitle,
		TemplateTitle_IdCard,
		TemplateField_IdCard_Name,
		TemplateField_IdCard_PlaceOfIssue,
		TemplateField_IdCard_IssueDate,
		TemplateTitle_EMail,
		TemplateField_EMail_EMail,
		TemplateTitle_WLan,
		TemplateTitle_Notes,
		TemplateField_WLan_SSID,
		TemplateField_Number,
		TemplateField_CreditCard_CVV,
		TemplateField_CreditCard_PIN,
		TemplateField_CreditCard_Owner,
		TemplateTitle_CreditCard,
		TemplateTitle_Membership,
		TemplateGroupName,
		AskAddTemplatesTitle,
		AskAddTemplatesMessage,
		ReadOnlyReason_PreKitKat,
		ReadOnlyReason_ReadOnlyFlag,
		ReadOnlyReason_ReadOnlyKitKat,
        ReadOnlyReason_LocalBackup,
        Ok,
        cancel,
        FileNotFound
    }
}
