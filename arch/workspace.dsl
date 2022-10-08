workspace {

    model {
        user = person "User"
        yahoo = softwareSystem "Yahoo Finance"
        stonksy = softwareSystem "Stonksy" {
            app = container "Stonksy.App" "Provides information about some stocks" ".NET 6" {
                stonkprovider = component "StockDataProvider" "Provide stock data" "Dotnet Module" {
                    this -> yahoo "Download stock data"
                }
                stonkpredictor = component "StockDataPredictor" "Predict future price of stock" "Dotnet Module" {
                }
                stockdatahistory = component "StockDataHistory" "Provide stock data history" "Dotnet Module" {
                    this -> stonkpredictor "StockWasChanged" "rabbitmq"
                    stonkprovider -> this "StockWasDownloaded" "rabbitmq"
                }
            }
            historydb = container "HistoryDatabase" "Stores information abaout stock histor" "Database" {
                stockdatahistory -> this "Read/Write stock "
            }
        }
        user -> stonksy "Uses"
        stonksy -> yahoo "Download stock data"
    }

    views {
        systemContext stonksy "Stonksy" {
            include *
            autoLayout
        }

        container stonksy "Containers" {
            include *
            autoLayout
        }

        component app "Components" {
            include *
            autoLayout
        }

        styles {
            element "Person" {
                color #ffffff
                fontSize 22
                shape Person
            }
            element "Klient portalu rossmann" {
                background #08427b
            }
            element "Bank Staff" {
                background #999999
            }
            element "Software System" {
                background #1168bd
                color #ffffff
            }
            element "Existing System" {
                background #999999
                color #ffffff
            }
            element "Container" {
                background #438dd5
                color #ffffff
            }
            element "Loyalty" {
                background #38D822
                color #ffffff
            }
            element "Web Browser" {
                shape WebBrowser
            }
            element "Mobile App" {
                shape MobileDeviceLandscape
            }
            element "Database" {
                shape Cylinder
            }
            element "Component" {
                background #85bbf0
                color #000000
            }
            element "Failover" {
                opacity 25
            }
        }
        
        theme default
        themes https://static.structurizr.com/themes/amazon-web-services-2020.04.30/theme.json
    }

}