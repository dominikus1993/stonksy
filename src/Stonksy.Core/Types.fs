namespace Stonksy.Core.Types

type Company = { Name: string }

type Companies = Company seq

type Stock = { Value: decimal }

type Stocks = Stock seq

type CompanyStocks = { Company: Company; Stocks: Stocks }