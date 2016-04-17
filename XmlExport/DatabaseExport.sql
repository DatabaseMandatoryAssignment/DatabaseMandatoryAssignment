Create Table Enhed
(
EnhedId INT NOT NULL,
EnhedNavn VARCHAR(100) NOT NULL
)

Insert into Enhed(EnhedId, EnhedNavn)
Select EnhedId, EnhedNavn
From(
	select EnhedId, EnhedNavn from Ambient_Enhed
	union
	select EnhedId, EnhedNavn from FilterPackAnalyse_Enhed
	union
	select EnhedId, EnhedNavn from FilterPackFlow_Enhed
	union
	select EnhedId, EnhedNavn from KorrektionGas_Enhed
	union
	select EnhedId, EnhedNavn from WaterAnalysis_Enhed
	union
	select EnhedId, EnhedNavn from WaterSample_Enhed
)t1

Create Table Maalested
(
MaalestedId INT NOT NULL,
MaalestedNavn VARCHAR(100) NOT NULL
)

Insert into Maalested(MaalestedId, MaalestedNavn)
Select MaalestedId, MaalestedNavn
From(
	select MaalestedId, MaalestedNavn from FilterPackAnalyse_MaaleSted
	union
	select MaalestedId, MaalestedNavn from FilterPackFlow_MaaleSted
	union
	select MaalestedId, MaalestedNavn from KorrektionGas_MaaleSted
	union
	select MaalestedId, MaalestedNavn from WaterAnalysis_MaaleSted
	union
	select MaalestedId, MaalestedNavn from Ambient_MaaleSted
	union
	select MaalestedId, MaalestedNavn from WaterSample_MaaleSted
)t2

Create Table Opstilling
(
OpstillingId INT NOT NULL,
OpstillingNavn VARCHAR(100) NOT NULL
)

Insert into Opstilling(OpstillingId, OpstillingNavn)
Select OpstillingId, OpstillingNavn
From(
	select OpstillingId, OpstillingNavn from Ambient_Opstilling
	union
	select OpstillingId, OpstillingNavn from FilterPackAnalyse_Opstilling
	union
	select OpstillingId, OpstillingNavn from FilterPackFlow_Opstilling
	union
	select OpstillingId, OpstillingNavn from InstrumentinfoGas_Opstilling
	union
	select OpstillingId, OpstillingNavn from InstrumentInfoSm200_Opstilling
	union
	select OpstillingId, OpstillingNavn from KorrektionGas_Opstilling
	union
	select OpstillingId, OpstillingNavn from WaterAnalysis_Opstilling
	union
	select OpstillingId, OpstillingNavn from WaterSample_Opstilling
)t3

Create Table Stof
(
StofId INT NOT NULL,
StofNavn VARCHAR(100) NOT NULL
)

Insert into Stof(StofId, StofNavn)
Select StofId, StofNavn
From(
	select StofId, StofNavn from Ambient_Stof
	union
	select StofId, StofNavn from FilterPackAnalyse_Stof
	union
	select StofId, StofNavn from FilterPackFlow_Stof
	union
	select StofId, StofNavn from KorrektionGas_Stof
	union
	select StofId, StofNavn from WaterAnalysis_Stof
	union
	select StofId, StofNavn from WaterSample_Stof
)t4

Create Table Udstyr
(
UdstyrId INT NOT NULL,
UdstyrNavn VARCHAR(100) NOT NULL
)

Insert into Udstyr(UdstyrId, UdstyrNavn)
Select UdstyrId, Navn
From(
	
	select UdstyrId, Navn from FilterPackFlow_Udstyr
	union
	select UdstyrId, UdstyrNavn from WaterAnalysis_Udstyr
	union
	select UdstyrId, UdstyrNavn from Ambient_Udstyr
	union
	select UdstyrId, UdstyrNavn from WaterSample_Udstyr
)t5

Create Table AnalyseApparat
(
AnalyseApparatId INT NOT NULL,
AnalyseApparatNavn VARCHAR(100) NOT NULL
)

Insert into AnalyseApparat(AnalyseApparatId, AnalyseApparatNavn)
Select AnalyseApparatId, AnalyseApparat
From(
	select AnalyseApparatId, AnalyseApparat from FilterPackAnalyse_AnalyseApparat
	union
	select AnalyseApparatId, AnalyseApparat from WaterAnalysis_AnalyseApparat
)t6

Create Table ProeveType
(
ProeveTypeId INT NOT NULL,
ProeveTypeNavn VARCHAR(100) NOT NULL
)

Insert into ProeveType(ProeveTypeId, ProeveTypeNavn)
Select ProeveTypeId, ProeveTypeNavn
From(
	select ProeveTypeId, ProeveTypeNavn from FilterPackAnalyse_ProeveType
	union
	select ProeveTypeId, ProeveTypeNavn from WaterAnalysis_ProeveType
)t7

Create Table KorrektionDataType
(
KorrektionDataTypeId INT NOT NULL,
KorrektionDataTypeNavn VARCHAR(100) NOT NULL
)

Insert into KorrektionDataType(KorrektionDataTypeId, KorrektionDataTypeNavn)
Select KorrektionDataTypeId, DataTypeNavn
From(
	select KorrektionDataTypeId, DataTypeNavn from KorrektionGas_KorrektionDataType
)t8

