USE [SDKInterfaceLibrary]
GO

/*
	Table: tblSDKHeaderBaseClassSpecifier

	Generated automatically by DiaHeadersSqlTransformer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=09006a76b6b1ba0d, Author: u164225, Date: 10/13/2016 4:38:07 PM
	Maps to class VisualStudioProvider.PDB.Headers.BaseClassSpecifier

	<References>
		<Reference>Class</Reference>
		<Reference>Type</Reference>
		<Reference>HeaderFile</Reference>
	</References>
*/


CREATE TABLE [dbo].[tblSDKHeaderBaseClassSpecifier](
		[BaseClassSpecifierId] [uniqueidentifier] NOT NULL,
		[HeaderFileId] [uniqueidentifier] NOT NULL,
		[OwningClassId] [uniqueidentifier] NULL,
		[TypeId] [uniqueidentifier] NULL,
		[Access] [nvarchar](255) NOT NULL,
		[IsVirtual] [bit] NOT NULL,
		[Offset] [int] NOT NULL,
 CONSTRAINT [PK_tblSDKHeaderBaseClassSpecifier] PRIMARY KEY CLUSTERED
(
	[BaseClassSpecifierId] ASC
)

WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] 

GO
