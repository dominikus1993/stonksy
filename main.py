import asyncio
import aiohttp
from aiohttp.client import ClientSession

companies_url ="https://pkgstore.datahub.io/core/nasdaq-listings/nasdaq-listed_csv/data/7665719fb51081ba0bd834fde71ce822/nasdaq-listed_csv.csv"

async def download_companies(): 
    async with ClientSession() as session:
        async with session.get(companies_url) as response:
            print(f'Status {response.status}')
            companies = await response.text()
            return companies

a = asyncio.run(download_companies())

print(a)
