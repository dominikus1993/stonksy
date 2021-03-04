import pandas as pd
import io
import requests

COMPANIES_URL ="https://pkgstore.datahub.io/core/nasdaq-listings/nasdaq-listed_csv/data/7665719fb51081ba0bd834fde71ce822/nasdaq-listed_csv.csv"

def download_companies(): 
    csv = requests.get(COMPANIES_URL).content
    stringIO = io.StringIO(csv.decode('utf-8'))
    return pd.read_csv(stringIO, index_col=None, header=0)

