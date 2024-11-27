# main.py
from econ_api_client import EconApiClient
from excel_reader import ExcelReader
from data_transformer import DataTransformer

def main():
    # Step 1: Initialize components
    api_token = "your-api-token"
    app_secret_token = "your-app-secret"
    excel_file_path = "path_to_your_file.xlsx"

    # API client
    api_client = EconApiClient(api_token, app_secret_token)
    # Excel reader
    excel_reader = ExcelReader(excel_file_path)
    # Read data
    data = excel_reader.read_data()

    # Step 2: Transform and send data
    transformer = DataTransformer(data)
    for _, row in data.iterrows():
        payload = transformer.transform_row_to_payload(row)
        try:
            response = api_client.post("invoices", payload)
            print(f"Invoice created: {response}")
        except Exception as e:
            print(f"Error creating invoice for {row['CustomerNumber']}: {e}")

if __name__ == "__main__":
    main()
