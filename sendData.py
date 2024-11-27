# data_transformer.py

class DataTransformer:
    def __init__(self, data):
        self.data = data

    def transform_row_to_payload(self, row):
        return {
            "customer": {"customerNumber": row['CustomerNumber']},
            "date": row['InvoiceDate'],
            "lines": [
                {
                    "description": row['Description'],
                    "unitNetPrice": row['Amount'],
                    "quantity": row['Quantity']
                }
            ]
        }
