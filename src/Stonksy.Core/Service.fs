namespace Stonksy.Core

open Stonksy.Core.Types
open Stonksy.Core.Utils
module Service =
    
    
    type DownloadCompanies = unit -> Async<Option<Companies>>
    type DownloadCompanyStock = Company -> Async<Option<CompanyStocks>>
    
    let private downloadC(downloadCompanyStock: DownloadCompanyStock)(company: Companies) =
        
    let downloadCompanyStocks (downloadCompanies: DownloadCompanies)()() =
        downloadCompanies()
            