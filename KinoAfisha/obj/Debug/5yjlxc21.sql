DECLARE @CurrentMigration [nvarchar](max)

IF object_id('[dbo].[__MigrationHistory]') IS NOT NULL
    SELECT @CurrentMigration =
        (SELECT TOP (1) 
        [Project1].[MigrationId] AS [MigrationId]
        FROM ( SELECT 
        [Extent1].[MigrationId] AS [MigrationId]
        FROM [dbo].[__MigrationHistory] AS [Extent1]
        WHERE [Extent1].[ContextKey] = N'Market.Migrations.Configuration'
        )  AS [Project1]
        ORDER BY [Project1].[MigrationId] DESC)

IF @CurrentMigration IS NULL
    SET @CurrentMigration = '0'

IF @CurrentMigration < '202111161818311_Init'
BEGIN
    CREATE TABLE [dbo].[Kinoes] (
        [Id] [int] NOT NULL IDENTITY,
        [Name] [nvarchar](max) NOT NULL,
        [Price] [decimal](18, 2) NOT NULL,
        [NumberOfBilets] [int] NOT NULL,
        [Place] [nvarchar](max) NOT NULL,
        [NextArrivalDate] [datetime] NOT NULL,
        [CreateAt] [datetime] NOT NULL,
        CONSTRAINT [PK_dbo.Kinoes] PRIMARY KEY ([Id])
    )
    CREATE TABLE [dbo].[__MigrationHistory] (
        [MigrationId] [nvarchar](150) NOT NULL,
        [ContextKey] [nvarchar](300) NOT NULL,
        [Model] [varbinary](max) NOT NULL,
        [ProductVersion] [nvarchar](32) NOT NULL,
        CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY ([MigrationId], [ContextKey])
    )
    INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
    VALUES (N'202111161818311_Init', N'Market.Migrations.Configuration',  0x1F8B0800000000000400CD58DB6EDB38107D5FA0FF20E8A90BA4662E2F6D20B770ED6411B48E8DCAED3B2D8D6CA224A52529C3FEB63EEC27ED2F74685D4DD9B19D14DD45804022670ECF0C398723FFFBE39FE0C35A706F054AB354F6FDABDEA5EF818CD298C945DFCF4DF2E6ADFFE1FDAB3F82BB58ACBD6F95DD8DB5434FA9FBFED298EC96101D2D4150DD132C52A94E13D38B5241689C92EBCBCB77E4EA8A0042F888E579C1975C1A2660FB82AFC3544690999CF2711A03D7E538CE845B54EF910AD0198DA0EF7F62321D244C2F69AF30F6BD0167148984C013DFA352A6861AA479FB554368542A1761860394CF3619A05D42B98692FE6D637E6A2497D73612D238565051AE4D2ACE04BCBA2953435CF76725D8AF5387C9BBC3249B8D8D7A9BC02277BEE72E743BE4CA1AEDC96DCF8E5C7863AABE83B9A8F71F8F89FDBBF0863937B982BE84DC28CA2FBC693EE72CFA049B59FA1D645FE69CB72921299CDB19C0A1A94A335066F3059292E843EC7B64D78FB88EB55BCBA708E3419A9B6BDF7BC4C5E99C43BDE3AD9043932AF80B24286A209E526340498B01DB9C755677D6B2FFABD5F08861B1F898A4F567900BB3ECFBF8E87BF76C0D71355232F82A19D6163A1995C31E864FAF3A552CAA971D41C404E5BE3755F85496EF5BDF0B236A01F7C57F24A65CCC414D928F8C83D1C772798429A7D17F90A047589B81526C45F908F7B54E153ECF98381F6FA8005D07E64CA0803495D7AD47143B43199EBC56511645676730823D158A4A5616A92E53B3CBBB400EC1B430710B1B1A853AF60A01D8C7B566D5682F29C4B712697240A58331CD32DCE0966A97235E5848F6F04D78BE98890283447A8FA6D56CEB95B09EE9029C595C1A99DE33A50D6E1D9D53BB53C35874CCBA7B7020BFD57AED34BB72D664BDB2B6CFEE66B715D6856852788F5109D4A46D8050D328A5BCE3B6BD3129A76A8F360E539E0B79485F9FF22ED4AEED5F8C9C8E502A571BA21C3A8385A34F3B7C9CB93398154AB5C3AC183A83992B3B3BD4DCC9D3711BF9690336A35DA48038E7C63D9BA473389D5BD63DE94F49856B52AF5E4B86230D4159A6C7BBBC4EDD1626F6B64B572CB6351B6EB401D1B306BDF06F3EE40CE36D0CC654B204B4291A111F3BAD6BA753FCFF746D44EB989FD0BAFDF64E8AD98C1EED95CEBDA55BCD935C51152DA97A2DE8FACF973544F1EF6988B62979493BF4B2900FB438313E9B5FD1E29C08745E8BD3BD858FB72F07BB97420990E91C5F6605433B03FAD99D4D579602D2FE440D46A0D9A281B01FAC12225BEF0D6865F32093B44A3286D4665499387B30064331EF74A00C4B6864703A02ADB74DF337CA7334B9C3A3183FC8496EB2DC0CB40631E73B5F2901797AFD6DFBB6CB399864F64DFF8A109026B34767223FE68CC735EFFB3D47E700843D24A5CA202BFC6840B8C5A6467A4CE5894065FA469081B41A3503917104D31319D2153C871BF6DF9F6141A34D75BB1C0639BE11BB690F468C2E1415BAC468FCEDCF2EC4FEEEF2FE27BAA84927A9110000 , N'6.4.4')
END

