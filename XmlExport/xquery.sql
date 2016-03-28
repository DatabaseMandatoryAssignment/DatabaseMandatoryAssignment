
PASTEBIN
new paste
trends API tools faq
 
Guest User
-
Public Pastes

    Untitled3 sec ago
    Dericks Bandit cam...12 sec ago
    guiLua | 21 sec ago
    Untitled24 sec ago
    Untitled25 sec ago
    Untitled38 sec ago
    Untitled42 sec ago
    Untitled46 sec ago

Pastebin PRO Accounts EASTER SPECIAL! For a limited time only get 40% discount on a LIFETIME PRO account! Offer Ends Soon!
SHARE
TWEET
Untitled
a guest Mar 28th, 2016 31 Never
rawdownloadcloneembedreportprint text 12.51 KB

DECLARE @x xml
 
SELECT @x=P
FROM OPENROWSET (BULK 'C:\Users\Selzamouri\Desktop\Database\Data\WaterAnalysis.xml', SINGLE_BLOB) AS Products(P)
 
DECLARE @hdoc int
 
EXEC sp_xml_preparedocument @hdoc OUTPUT, @x
 
SELECT DISTINCT *
INTO WaterAnalysis_MaaleSted
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
        MaaleStedId INT,
        MaalestedNavn VARCHAR(100)
        )
 
EXEC sp_xml_removedocument @hdoc
 
EXEC sp_xml_preparedocument @hdoc OUTPUT, @x
 
SELECT DISTINCT *
INTO WaterAnalysis_Opstilling
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
        OpstillingId INT,
        OpstillingNavn VARCHAR(100)
        )
 
EXEC sp_xml_removedocument @hdoc
 
EXEC sp_xml_preparedocument @hdoc OUTPUT, @x
 
SELECT DISTINCT *
INTO WaterAnalysis_Stof
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
        StofId INT,
        StofNavn VARCHAR(100)
        )
 
EXEC sp_xml_removedocument @hdoc
 
EXEC sp_xml_preparedocument @hdoc OUTPUT, @x
 
SELECT DISTINCT *
INTO WaterAnalysis_Enhed
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
        EnhedId INT,
        EnhedNavn    VARCHAR(100)
        )
 
EXEC sp_xml_removedocument @hdoc
 
EXEC sp_xml_preparedocument @hdoc OUTPUT, @x
 
SELECT DISTINCT *
INTO WaterAnalysis_Udstyr
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
        UdstyrId INT,
        UdstyrNavn VARCHAR(100)
        )
 
EXEC sp_xml_removedocument @hdoc
 
EXEC sp_xml_preparedocument @hdoc OUTPUT, @x
 
SELECT DISTINCT *
INTO WaterAnalysis_AnalyseApparat
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
        AnalyseApparatId INT,
        AnalyseApparat VARCHAR(100)
        )
 
EXEC sp_xml_removedocument @hdoc
 
EXEC sp_xml_preparedocument @hdoc OUTPUT, @x
 
SELECT DISTINCT *
INTO WaterAnalysis_ProeveType
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
        ProeveTypeId INT,
        ProeveTypeNavn VARCHAR(100)
        )
 
EXEC sp_xml_removedocument @hdoc
 
EXEC sp_xml_preparedocument @hdoc OUTPUT, @x
 
SELECT *
INTO WaterAnalysis
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
        DatoMaerke DATETIME,
        MaaleStedId INT,
        OpstillingId INT,
        StofId INT,
        Resultat FLOAT,
        EnhedId INT,
        UdstyrId INT,
        AnalyseApparatId INT,
        ProeveTypeId INT
        )
 
EXEC sp_xml_removedocument @hdoc
 
DECLARE @x1 xml
 
SELECT @x1=P
FROM OPENROWSET (BULK 'C:\Users\Selzamouri\Desktop\Database\Data\Korrektion_Gas.xml', SINGLE_BLOB) AS Products(P)
 
EXEC sp_xml_preparedocument @hdoc OUTPUT, @x1
 
SELECT *
INTO KorrektionGas
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
        DatoMaerke DATETIME,
        MaaleStedId INT,
        OpstillingId INT,
        StofId INT,
        Korrektion FLOAT,
        EnhedId INT,
        KorrektionDataTypeId INT
        )
 
EXEC sp_xml_removedocument @hdoc
 
EXEC sp_xml_preparedocument @hdoc OUTPUT, @x1
 
SELECT DISTINCT *
INTO KorrektionGas_KorrektionDataType
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
        KorrektionDataTypeId INT,
        DataTypeNavn VARCHAR(100)
        )
 
EXEC sp_xml_removedocument @hdoc
 
EXEC sp_xml_preparedocument @hdoc OUTPUT, @x1
 
SELECT DISTINCT *
INTO KorrektionGas_MaaleSted
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
        MaaleStedId INT,
        MaalestedNavn VARCHAR(100)
        )
 
EXEC sp_xml_removedocument @hdoc
 
EXEC sp_xml_preparedocument @hdoc OUTPUT, @x1
 
SELECT DISTINCT *
INTO KorrektionGas_Opstilling
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
        OpstillingId INT,
        OpstillingNavn VARCHAR(100)
        )
 
EXEC sp_xml_removedocument @hdoc
 
EXEC sp_xml_preparedocument @hdoc OUTPUT, @x1
 
SELECT DISTINCT *
INTO KorrektionGas_Stof
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
        StofId INT,
        StofNavn VARCHAR(100)
        )
 
EXEC sp_xml_removedocument @hdoc
 
EXEC sp_xml_preparedocument @hdoc OUTPUT, @x1
 
SELECT DISTINCT *
INTO KorrektionGas_Enhed
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
        EnhedId INT,
        EnhedNavn VARCHAR(100)
        )
 
EXEC sp_xml_removedocument @hdoc
 
DECLARE @x2 xml
 
SELECT @x2=P
FROM OPENROWSET (BULK 'C:\Users\Selzamouri\Desktop\Database\Data\Instrumentinfo_Gas.xml', SINGLE_BLOB) AS Products(P)
 
EXEC sp_xml_preparedocument @hdoc OUTPUT, @x2
 
SELECT *
INTO InstrumentinfoGas
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
        DatoMaerke DATETIME,
        OpstillingId INT,
        MonitorId INT,
        K INT
        )
 
EXEC sp_xml_removedocument @hdoc
 
EXEC sp_xml_preparedocument @hdoc OUTPUT, @x2
 
SELECT DISTINCT *
INTO InstrumentinfoGas_Monitor
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
        MonitorId INT,
        Antal_Maalinger INT
        )
 
EXEC sp_xml_removedocument @hdoc
 
EXEC sp_xml_preparedocument @hdoc OUTPUT, @x2
 
SELECT DISTINCT *
INTO InstrumentinfoGas_Opstilling
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
        OpstillingId INT,
        OpstillingNavn VARCHAR(100)
        )
 
EXEC sp_xml_removedocument @hdoc
 
DECLARE @x3 xml
 
SELECT @x3=P
FROM OPENROWSET (BULK 'C:\Users\Selzamouri\Desktop\Database\Data\WaterSamples.xml', SINGLE_BLOB) AS Products(P)
 
EXEC sp_xml_preparedocument @hdoc OUTPUT, @x3
 
SELECT *
INTO WaterSample
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
        DatoMaerke DATETIME,
        MaaleStedId INT,
        OpstillingId INT,
        StofId INT,
        Resultat FLOAT,
        EnhedId INT,
        UdstyrId INT,
        Easting_32 INT,
        Northing_32 INT
        )
 
EXEC sp_xml_removedocument @hdoc
 
EXEC sp_xml_preparedocument @hdoc OUTPUT, @x3
 
SELECT DISTINCT *
INTO WaterSample_MaaleSted
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
        MaaleStedId INT,
        Maalested VARCHAR(100)
        )
 
EXEC sp_xml_removedocument @hdoc
 
EXEC sp_xml_preparedocument @hdoc OUTPUT, @x3
 
SELECT DISTINCT *
INTO WaterSample_Opstilling
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
        OpstillingId INT,
        OpstillingNavn VARCHAR(100)
        )
 
EXEC sp_xml_removedocument @hdoc
 
EXEC sp_xml_preparedocument @hdoc OUTPUT, @x3
 
SELECT DISTINCT *
INTO WaterSample_Stof
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
        StofId INT,
        StofNavn VARCHAR(100)
        )
 
EXEC sp_xml_removedocument @hdoc
 
EXEC sp_xml_preparedocument @hdoc OUTPUT, @x3
 
SELECT DISTINCT *
INTO WaterSample_Enhed
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
        EnhedId INT,
        EnhedNavn VARCHAR(100)
        )
 
EXEC sp_xml_removedocument @hdoc
 
EXEC sp_xml_preparedocument @hdoc OUTPUT, @x3
 
SELECT DISTINCT *
INTO WaterSample_Udstyr
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
        UdstyrId INT,
        UdstyrNavn VARCHAR(100)
        )
 
EXEC sp_xml_removedocument @hdoc
 
DECLARE @x4 xml
 
SELECT @x4=P
FROM OPENROWSET (BULK 'C:\Users\Selzamouri\Desktop\Database\Data\InstrumentInfo_Sm200.xml', SINGLE_BLOB) AS Products(P)
 
EXEC sp_xml_preparedocument @hdoc OUTPUT, @x4
 
SELECT *
INTO InstrumentInfoSm200
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
        DatoMaerke DATETIME,
        OpstillingId INT,
        SamplingTime INT,
        TotalMass FLOAT,
        MassError FLOAT,
        PneumaticStatus INT,
        BetaStatus INT,
        InitialPressureDrop FLOAT,
        FinalPressureDrop FLOAT,
        CollectMeanTemp FLOAT,
        CollectMeanPress FLOAT,
        BufferNr INT
        )
 
EXEC sp_xml_removedocument @hdoc
 
EXEC sp_xml_preparedocument @hdoc OUTPUT, @x4
 
SELECT DISTINCT *
INTO InstrumentInfoSm200_Opstilling
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
        OpstillingId INT,
        OpstillingNavn VARCHAR(100)
        )
 
EXEC sp_xml_removedocument @hdoc
 
DECLARE @x5 xml
 
SELECT @x5=P
FROM OPENROWSET (BULK 'C:\Users\Selzamouri\Desktop\Database\Data\FilterPackFlow.xml', SINGLE_BLOB) AS Products(P)
 
EXEC sp_xml_preparedocument @hdoc OUTPUT, @x5
 
SELECT *
INTO FilterPackFlow
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
        DatoMaerke DATETIME,
        MaaleStedId INT,
        OpstillingId INT,
        StofId INT,
        Resultat FLOAT,
        EnhedId INT,
        UdstyrId INT,
        Easting_32 INT,
        Northing_32 INT
        )
 
EXEC sp_xml_removedocument @hdoc
 
EXEC sp_xml_preparedocument @hdoc OUTPUT, @x5
 
SELECT DISTINCT *
INTO FilterPackFlow_MaaleSted
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
        MaaleStedId INT,
        MaalestedNavn VARCHAR(100)
        )
 
EXEC sp_xml_removedocument @hdoc
 
EXEC sp_xml_preparedocument @hdoc OUTPUT, @x5
 
SELECT DISTINCT *
INTO FilterPackFlow_Opstilling
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
        OpstillingId INT,
        OpstillingNavn VARCHAR(100)
        )
 
EXEC sp_xml_removedocument @hdoc
 
EXEC sp_xml_preparedocument @hdoc OUTPUT, @x5
 
SELECT DISTINCT *
INTO FilterPackFlow_Stof
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
        StofId INT,
        StofNavn VARCHAR(100)
        )
 
EXEC sp_xml_removedocument @hdoc
 
EXEC sp_xml_preparedocument @hdoc OUTPUT, @x5
 
SELECT DISTINCT *
INTO FilterPackFlow_Enhed
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
        EnhedId INT,
        EnhedNavn VARCHAR(100)
        )
 
EXEC sp_xml_removedocument @hdoc
 
EXEC sp_xml_preparedocument @hdoc OUTPUT, @x5
 
SELECT DISTINCT *
INTO FilterPackFlow_Udstyr
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
        UdstyrId INT,
        Navn VARCHAR(100)
        )
 
EXEC sp_xml_removedocument @hdoc
 
 
DECLARE @x6 xml
 
SELECT @x6=P
FROM OPENROWSET (BULK 'C:\Users\Selzamouri\Desktop\Database\Data\FilterPackAnalyse.xml', SINGLE_BLOB) AS Products(P)
 
EXEC sp_xml_preparedocument @hdoc OUTPUT, @x6
 
SELECT *
INTO FilterPackAnalyse
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
        DatoMaerke DATETIME,
        MaaleStedId INT,
        OpstillingId INT,
        StofId INT,
        Resultat FLOAT,
        EnhedId INT,
        AnalyseApparatId INT,
        ProeveTypeId INT
        )
 
EXEC sp_xml_removedocument @hdoc
 
EXEC sp_xml_preparedocument @hdoc OUTPUT, @x6
 
SELECT DISTINCT *
INTO FilterPackAnalyse_MaaleSted
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
        MaaleStedId INT,
        MaalestedNavn VARCHAR(100)
        )
 
EXEC sp_xml_removedocument @hdoc
 
EXEC sp_xml_preparedocument @hdoc OUTPUT, @x6
 
SELECT DISTINCT *
INTO FilterPackAnalyse_Opstilling
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
        OpstillingId INT,
        OpstillingNavn VARCHAR(100)
        )
 
EXEC sp_xml_removedocument @hdoc
 
EXEC sp_xml_preparedocument @hdoc OUTPUT, @x6
 
SELECT DISTINCT *
INTO FilterPackAnalyse_Stof
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
        StofId INT,
        StofNavn VARCHAR(100)
        )
 
EXEC sp_xml_removedocument @hdoc
 
EXEC sp_xml_preparedocument @hdoc OUTPUT, @x6
 
SELECT DISTINCT *
INTO FilterPackAnalyse_Enhed
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
        EnhedId INT,
        EnhedNavn VARCHAR(100)
        )
 
EXEC sp_xml_removedocument @hdoc
 
EXEC sp_xml_preparedocument @hdoc OUTPUT, @x6
 
SELECT DISTINCT *
INTO FilterPackAnalyse_AnalyseApparat
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
        AnalyseApparatId INT,
        AnalyseApparat VARCHAR(100)
        )
 
EXEC sp_xml_removedocument @hdoc
 
EXEC sp_xml_preparedocument @hdoc OUTPUT, @x6
 
SELECT DISTINCT *
INTO FilterPackAnalyse_ProeveType
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
        ProeveTypeId INT,
        ProeveTypeNavn VARCHAR(100)
        )
 
EXEC sp_xml_removedocument @hdoc
 
DECLARE @x7 xml
 
SELECT @x7=P
FROM OPENROWSET (BULK 'C:\Users\Selzamouri\Desktop\Database\Data\Ambient.xml', SINGLE_BLOB) AS Products(P)
 
EXEC sp_xml_preparedocument @hdoc OUTPUT, @x7
 
SELECT *
INTO Ambient
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
        DatoMaerke DATETIME,
        MaaleStedId INT,
        OpstillingId INT,
        StofId INT,
        Resultat FLOAT,
        EnhedId INT,
        UdstyrId INT,
        Easting_32 INT,
        Northing_32 INT
        )
 
EXEC sp_xml_removedocument @hdoc
 
EXEC sp_xml_preparedocument @hdoc OUTPUT, @x7
 
SELECT DISTINCT *
INTO Ambient_MaaleSted
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
        MaaleStedId INT,
        Maalested VARCHAR(100)
        )
 
EXEC sp_xml_removedocument @hdoc
 
EXEC sp_xml_preparedocument @hdoc OUTPUT, @x7
 
SELECT DISTINCT *
INTO Ambient_Opstilling
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
        OpstillingId INT,
        OpstillingNavn VARCHAR(100)
        )
 
EXEC sp_xml_removedocument @hdoc
 
EXEC sp_xml_preparedocument @hdoc OUTPUT, @x7
 
SELECT DISTINCT *
INTO Ambient_Stof
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
        StofId INT,
        StofNavn VARCHAR(100)
        )
 
EXEC sp_xml_removedocument @hdoc
 
EXEC sp_xml_preparedocument @hdoc OUTPUT, @x7
 
SELECT DISTINCT *
INTO Ambient_Enhed
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
        EnhedId INT,
        EnhedNavn VARCHAR(100)
        )
 
EXEC sp_xml_removedocument @hdoc
 
EXEC sp_xml_preparedocument @hdoc OUTPUT, @x7
 
SELECT DISTINCT *
INTO Ambient_Udstyr
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
        UdstyrId INT,
        UdstyrNavn VARCHAR(100)
        )
 

    EXEC sp_xml_removedocument @hdoc

RAW Paste Data
DECLARE @x xml

SELECT @x=P
FROM OPENROWSET (BULK 'C:\Users\Selzamouri\Desktop\Database\Data\WaterAnalysis.xml', SINGLE_BLOB) AS Products(P)

DECLARE @hdoc int

EXEC sp_xml_preparedocument @hdoc OUTPUT, @x

SELECT DISTINCT *
INTO WaterAnalysis_MaaleSted
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
		MaaleStedId INT,
		MaalestedNavn VARCHAR(100)
		)

EXEC sp_xml_removedocument @hdoc

EXEC sp_xml_preparedocument @hdoc OUTPUT, @x

SELECT DISTINCT *
INTO WaterAnalysis_Opstilling
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
		OpstillingId INT,
		OpstillingNavn VARCHAR(100)
		)

EXEC sp_xml_removedocument @hdoc

EXEC sp_xml_preparedocument @hdoc OUTPUT, @x

SELECT DISTINCT *
INTO WaterAnalysis_Stof
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
		StofId INT,
		StofNavn VARCHAR(100)
		)

EXEC sp_xml_removedocument @hdoc

EXEC sp_xml_preparedocument @hdoc OUTPUT, @x

SELECT DISTINCT *
INTO WaterAnalysis_Enhed
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
		EnhedId INT,
		EnhedNavn	 VARCHAR(100)
		)

EXEC sp_xml_removedocument @hdoc

EXEC sp_xml_preparedocument @hdoc OUTPUT, @x

SELECT DISTINCT *
INTO WaterAnalysis_Udstyr
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
		UdstyrId INT,
		UdstyrNavn VARCHAR(100)
		)

EXEC sp_xml_removedocument @hdoc

EXEC sp_xml_preparedocument @hdoc OUTPUT, @x

SELECT DISTINCT *
INTO WaterAnalysis_AnalyseApparat
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
		AnalyseApparatId INT,
		AnalyseApparat VARCHAR(100)
		)

EXEC sp_xml_removedocument @hdoc

EXEC sp_xml_preparedocument @hdoc OUTPUT, @x

SELECT DISTINCT *
INTO WaterAnalysis_ProeveType
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
		ProeveTypeId INT,
		ProeveTypeNavn VARCHAR(100)
		)

EXEC sp_xml_removedocument @hdoc

EXEC sp_xml_preparedocument @hdoc OUTPUT, @x

SELECT *
INTO WaterAnalysis
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
		DatoMaerke DATETIME,
		MaaleStedId INT,
		OpstillingId INT,
		StofId INT,
		Resultat FLOAT,
		EnhedId INT,
		UdstyrId INT,
		AnalyseApparatId INT,
		ProeveTypeId INT
		)

EXEC sp_xml_removedocument @hdoc

DECLARE @x1 xml

SELECT @x1=P
FROM OPENROWSET (BULK 'C:\Users\Selzamouri\Desktop\Database\Data\Korrektion_Gas.xml', SINGLE_BLOB) AS Products(P)

EXEC sp_xml_preparedocument @hdoc OUTPUT, @x1

SELECT *
INTO KorrektionGas
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
		DatoMaerke DATETIME,
		MaaleStedId INT,
		OpstillingId INT,
		StofId INT,
		Korrektion FLOAT,
		EnhedId INT,
		KorrektionDataTypeId INT
		)

EXEC sp_xml_removedocument @hdoc

EXEC sp_xml_preparedocument @hdoc OUTPUT, @x1

SELECT DISTINCT *
INTO KorrektionGas_KorrektionDataType
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
		KorrektionDataTypeId INT,
		DataTypeNavn VARCHAR(100)
		)

EXEC sp_xml_removedocument @hdoc

EXEC sp_xml_preparedocument @hdoc OUTPUT, @x1

SELECT DISTINCT *
INTO KorrektionGas_MaaleSted
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
		MaaleStedId INT,
		MaalestedNavn VARCHAR(100)
		)

EXEC sp_xml_removedocument @hdoc

EXEC sp_xml_preparedocument @hdoc OUTPUT, @x1

SELECT DISTINCT *
INTO KorrektionGas_Opstilling
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
		OpstillingId INT,
		OpstillingNavn VARCHAR(100)
		)

EXEC sp_xml_removedocument @hdoc

EXEC sp_xml_preparedocument @hdoc OUTPUT, @x1

SELECT DISTINCT *
INTO KorrektionGas_Stof
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
		StofId INT,
		StofNavn VARCHAR(100)
		)

EXEC sp_xml_removedocument @hdoc

EXEC sp_xml_preparedocument @hdoc OUTPUT, @x1

SELECT DISTINCT *
INTO KorrektionGas_Enhed
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
		EnhedId INT,
		EnhedNavn VARCHAR(100)
		)

EXEC sp_xml_removedocument @hdoc

DECLARE @x2 xml

SELECT @x2=P
FROM OPENROWSET (BULK 'C:\Users\Selzamouri\Desktop\Database\Data\Instrumentinfo_Gas.xml', SINGLE_BLOB) AS Products(P)

EXEC sp_xml_preparedocument @hdoc OUTPUT, @x2

SELECT *
INTO InstrumentinfoGas
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
		DatoMaerke DATETIME,
		OpstillingId INT,
		MonitorId INT,
		K INT
		)

EXEC sp_xml_removedocument @hdoc

EXEC sp_xml_preparedocument @hdoc OUTPUT, @x2

SELECT DISTINCT *
INTO InstrumentinfoGas_Monitor
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
		MonitorId INT,
		Antal_Maalinger INT
		)

EXEC sp_xml_removedocument @hdoc

EXEC sp_xml_preparedocument @hdoc OUTPUT, @x2

SELECT DISTINCT *
INTO InstrumentinfoGas_Opstilling
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
		OpstillingId INT,
		OpstillingNavn VARCHAR(100)
		)

EXEC sp_xml_removedocument @hdoc

DECLARE @x3 xml

SELECT @x3=P
FROM OPENROWSET (BULK 'C:\Users\Selzamouri\Desktop\Database\Data\WaterSamples.xml', SINGLE_BLOB) AS Products(P)

EXEC sp_xml_preparedocument @hdoc OUTPUT, @x3

SELECT *
INTO WaterSample
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
		DatoMaerke DATETIME,
		MaaleStedId INT,
		OpstillingId INT,
		StofId INT,
		Resultat FLOAT,
		EnhedId INT,
		UdstyrId INT,
		Easting_32 INT,
		Northing_32 INT
		)

EXEC sp_xml_removedocument @hdoc

EXEC sp_xml_preparedocument @hdoc OUTPUT, @x3

SELECT DISTINCT *
INTO WaterSample_MaaleSted
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
		MaaleStedId INT,
		Maalested VARCHAR(100)
		)

EXEC sp_xml_removedocument @hdoc

EXEC sp_xml_preparedocument @hdoc OUTPUT, @x3

SELECT DISTINCT *
INTO WaterSample_Opstilling
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
		OpstillingId INT,
		OpstillingNavn VARCHAR(100)
		)

EXEC sp_xml_removedocument @hdoc

EXEC sp_xml_preparedocument @hdoc OUTPUT, @x3

SELECT DISTINCT *
INTO WaterSample_Stof
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
		StofId INT,
		StofNavn VARCHAR(100)
		)

EXEC sp_xml_removedocument @hdoc

EXEC sp_xml_preparedocument @hdoc OUTPUT, @x3

SELECT DISTINCT *
INTO WaterSample_Enhed
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
		EnhedId INT,
		EnhedNavn VARCHAR(100)
		)

EXEC sp_xml_removedocument @hdoc

EXEC sp_xml_preparedocument @hdoc OUTPUT, @x3

SELECT DISTINCT *
INTO WaterSample_Udstyr
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
		UdstyrId INT,
		UdstyrNavn VARCHAR(100)
		)

EXEC sp_xml_removedocument @hdoc

DECLARE @x4 xml

SELECT @x4=P
FROM OPENROWSET (BULK 'C:\Users\Selzamouri\Desktop\Database\Data\InstrumentInfo_Sm200.xml', SINGLE_BLOB) AS Products(P)

EXEC sp_xml_preparedocument @hdoc OUTPUT, @x4

SELECT *
INTO InstrumentInfoSm200
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
		DatoMaerke DATETIME,
		OpstillingId INT,
		SamplingTime INT,
		TotalMass FLOAT,
		MassError FLOAT,
		PneumaticStatus INT,
		BetaStatus INT,
		InitialPressureDrop FLOAT,
		FinalPressureDrop FLOAT,
		CollectMeanTemp FLOAT,
		CollectMeanPress FLOAT,
		BufferNr INT
		)

EXEC sp_xml_removedocument @hdoc

EXEC sp_xml_preparedocument @hdoc OUTPUT, @x4

SELECT DISTINCT *
INTO InstrumentInfoSm200_Opstilling
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
		OpstillingId INT,
		OpstillingNavn VARCHAR(100)
		)

EXEC sp_xml_removedocument @hdoc

DECLARE @x5 xml

SELECT @x5=P
FROM OPENROWSET (BULK 'C:\Users\Selzamouri\Desktop\Database\Data\FilterPackFlow.xml', SINGLE_BLOB) AS Products(P)

EXEC sp_xml_preparedocument @hdoc OUTPUT, @x5

SELECT *
INTO FilterPackFlow
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
		DatoMaerke DATETIME,
		MaaleStedId INT,
		OpstillingId INT,
		StofId INT,
		Resultat FLOAT,
		EnhedId INT,
		UdstyrId INT,
		Easting_32 INT,
		Northing_32 INT
		)

EXEC sp_xml_removedocument @hdoc

EXEC sp_xml_preparedocument @hdoc OUTPUT, @x5

SELECT DISTINCT *
INTO FilterPackFlow_MaaleSted
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
		MaaleStedId INT,
		MaalestedNavn VARCHAR(100)
		)

EXEC sp_xml_removedocument @hdoc

EXEC sp_xml_preparedocument @hdoc OUTPUT, @x5

SELECT DISTINCT *
INTO FilterPackFlow_Opstilling
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
		OpstillingId INT,
		OpstillingNavn VARCHAR(100)
		)

EXEC sp_xml_removedocument @hdoc

EXEC sp_xml_preparedocument @hdoc OUTPUT, @x5

SELECT DISTINCT *
INTO FilterPackFlow_Stof
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
		StofId INT,
		StofNavn VARCHAR(100)
		)

EXEC sp_xml_removedocument @hdoc

EXEC sp_xml_preparedocument @hdoc OUTPUT, @x5

SELECT DISTINCT *
INTO FilterPackFlow_Enhed
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
		EnhedId INT,
		EnhedNavn VARCHAR(100)
		)

EXEC sp_xml_removedocument @hdoc

EXEC sp_xml_preparedocument @hdoc OUTPUT, @x5

SELECT DISTINCT *
INTO FilterPackFlow_Udstyr
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
		UdstyrId INT,
		Navn VARCHAR(100)
		)

EXEC sp_xml_removedocument @hdoc


DECLARE @x6 xml

SELECT @x6=P
FROM OPENROWSET (BULK 'C:\Users\Selzamouri\Desktop\Database\Data\FilterPackAnalyse.xml', SINGLE_BLOB) AS Products(P)

EXEC sp_xml_preparedocument @hdoc OUTPUT, @x6

SELECT *
INTO FilterPackAnalyse
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
		DatoMaerke DATETIME,
		MaaleStedId INT,
		OpstillingId INT,
		StofId INT,
		Resultat FLOAT,
		EnhedId INT,
		AnalyseApparatId INT,
		ProeveTypeId INT
		)

EXEC sp_xml_removedocument @hdoc

EXEC sp_xml_preparedocument @hdoc OUTPUT, @x6

SELECT DISTINCT *
INTO FilterPackAnalyse_MaaleSted
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
		MaaleStedId INT,
		MaalestedNavn VARCHAR(100)
		)

EXEC sp_xml_removedocument @hdoc

EXEC sp_xml_preparedocument @hdoc OUTPUT, @x6

SELECT DISTINCT *
INTO FilterPackAnalyse_Opstilling
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
		OpstillingId INT,
		OpstillingNavn VARCHAR(100)
		)

EXEC sp_xml_removedocument @hdoc

EXEC sp_xml_preparedocument @hdoc OUTPUT, @x6

SELECT DISTINCT *
INTO FilterPackAnalyse_Stof
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
		StofId INT,
		StofNavn VARCHAR(100)
		)

EXEC sp_xml_removedocument @hdoc

EXEC sp_xml_preparedocument @hdoc OUTPUT, @x6

SELECT DISTINCT *
INTO FilterPackAnalyse_Enhed
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
		EnhedId INT,
		EnhedNavn VARCHAR(100)
		)

EXEC sp_xml_removedocument @hdoc

EXEC sp_xml_preparedocument @hdoc OUTPUT, @x6

SELECT DISTINCT *
INTO FilterPackAnalyse_AnalyseApparat
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
		AnalyseApparatId INT,
		AnalyseApparat VARCHAR(100)
		)

EXEC sp_xml_removedocument @hdoc

EXEC sp_xml_preparedocument @hdoc OUTPUT, @x6

SELECT DISTINCT *
INTO FilterPackAnalyse_ProeveType
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
		ProeveTypeId INT,
		ProeveTypeNavn VARCHAR(100)
		)

EXEC sp_xml_removedocument @hdoc

DECLARE @x7 xml

SELECT @x7=P
FROM OPENROWSET (BULK 'C:\Users\Selzamouri\Desktop\Database\Data\Ambient.xml', SINGLE_BLOB) AS Products(P)

EXEC sp_xml_preparedocument @hdoc OUTPUT, @x7

SELECT *
INTO Ambient
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
		DatoMaerke DATETIME,
		MaaleStedId INT,
		OpstillingId INT,
		StofId INT,
		Resultat FLOAT,
		EnhedId INT,
		UdstyrId INT,
		Easting_32 INT,
		Northing_32 INT
		)

EXEC sp_xml_removedocument @hdoc

EXEC sp_xml_preparedocument @hdoc OUTPUT, @x7

SELECT DISTINCT *
INTO Ambient_MaaleSted
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
		MaaleStedId INT,
		Maalested VARCHAR(100)
		)

EXEC sp_xml_removedocument @hdoc

EXEC sp_xml_preparedocument @hdoc OUTPUT, @x7

SELECT DISTINCT *
INTO Ambient_Opstilling
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
		OpstillingId INT,
		OpstillingNavn VARCHAR(100)
		)

EXEC sp_xml_removedocument @hdoc

EXEC sp_xml_preparedocument @hdoc OUTPUT, @x7

SELECT DISTINCT *
INTO Ambient_Stof
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
		StofId INT,
		StofNavn VARCHAR(100)
		)

EXEC sp_xml_removedocument @hdoc

EXEC sp_xml_preparedocument @hdoc OUTPUT, @x7

SELECT DISTINCT *
INTO Ambient_Enhed
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
		EnhedId INT,
		EnhedNavn VARCHAR(100)
		)

EXEC sp_xml_removedocument @hdoc

EXEC sp_xml_preparedocument @hdoc OUTPUT, @x7

SELECT DISTINCT *
INTO Ambient_Udstyr
FROM OPENXML (@hdoc, '/DocumentElement/Data', 2)
WITH (
		UdstyrId INT,
		UdstyrNavn VARCHAR(100)
		)

EXEC sp_xml_removedocument @hdoc
create new paste  /  api  /  trends  /  syntax languages  /  faq  /  tools  /  privacy  /  cookies  /  contact  /  dmca  /  advertise on pastebin  /  scraping  /  go
Site design & logo © 2016 Pastebin; user contributions (pastes) licensed under cc by-sa 3.0 -- Dedicated Server Hosting by Steadfast
Top
