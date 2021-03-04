import asyncio
from asyncio.tasks import wait
from os import times
from aiohttp.client import ClientSession
import pandas as pd
import io
import requests
import infrastructure.services.companies as companies


res = companies.download_companies()


print(res)

