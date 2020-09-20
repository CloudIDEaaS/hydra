USE [SDKInterfaceLibrary]
GO

/*
	Table: tblSDKHeaderMacroExpansion

	Generated automatically by DiaHeadersSqlTransformer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=09006a76b6b1ba0d, Author: u164225, Date: 10/9/2016 11:53:41 AM
	Maps to class VisualStudioProvider.PDB.Headers.MacroExpansion

	<References>
		<Reference>MacroDefinition</Reference>
		<Reference>HeaderFile</Reference>
		<Reference>PreprocessedEntity</Reference>
	</References>
*/


CREATE TABLE [dbo].[tblSDKHeaderMacroExpansion](
		[MacroExpansionId] [uniqueidentifier] NOT NULL,
		[HeaderFileId] [uniqueidentifier] NOT NULL,
		[PreprocessedEntityId] [uniqueidentifier] NULL,
		[DefinitionMacroDefinitionId] [uniqueidentifier] NULL,
		[Name] [nvarchar](255) NOT NULL,
		[Text] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_tblSDKHeaderMacroExpansion] PRIMARY KEY CLUSTERED
(
	[MacroExpansionId] ASC
)

WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] 

GO
