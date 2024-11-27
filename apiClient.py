# econ_api_client.py
import requests

class EconApiClient:
    def __init__(self, api_token, app_secret_token):
        self.api_token = api_token
        self.app_secret_token = app_secret_token
        self.base_url = "https://restapi.e-conomic.com/"
        self.headers = {
            "X-AppSecretToken": app_secret_token,
            "X-AgreementGrantToken": api_token,
            "Content-Type": "application/json"
        }

    def post(self, endpoint, payload):
        url = f"{self.base_url}{endpoint}"
        response = requests.post(url, headers=self.headers, json=payload)
        if response.status_code >= 200 and response.status_code < 300:
            return response.json()
        else:
            response.raise_for_status()
