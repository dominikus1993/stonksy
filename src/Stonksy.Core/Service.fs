namespace Stonksy.Core

open Stonksy.Core.Types

module Service =
    
    type DownloadCompanies = unit -> Async<Option<Companies>>
    let downloadCompanyStocks (downloadCompanies: DownloadCompanies)() =
        async {
            let! companiesOpt = downloadCompanies()
            
        }