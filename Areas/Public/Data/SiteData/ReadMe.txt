﻿

Scaffold-DbContext "Server=sql7.hostinguk.net;Database=hairdemo;integrated security=False;User ID=hairdemo;Password=::L1ghting" Microsoft.EntityFrameworkCore.SqlServer -OutputDir "Areas/ClientAdmin/Data" -Context "cmsDbContext"


Scaffold-DbContext "Server=sql7.hostinguk.net;Database=hairdemo;integrated security=False;User ID=hairdemo;Password=::L1ghting" Microsoft.EntityFrameworkCore.SqlServer -OutputDir "Areas/Public/Data/SiteData" -Context "siteDataDbContext" -Tables "dbo.mpCarousel", "dbo.mpFlatPageData", "dbo.publicImages", "dbo.mpOurServices", "dbo.pageFooter" -force



Scaffold-DbContext [-Connection] [-Provider] [-OutputDir] [-Context] [-Schemas>] [-Tables>] 
                    [-DataAnnotations] [-Force] [-Project] [-StartupProject] [<CommonParameters>]


-- Create cert
New-SelfSignedCertificate -CertStoreLocation Cert:\LocalMachine\My -DnsName "localhost" -FriendlyName "localhost" -NotAfter (Get-Date).AddYears(10)