import React from 'react';
import { Button, FormControl, InputGroup } from 'react-bootstrap';

function StockSearch({ handleSearch }) {
    return (
        <div className="row search-stock">
            <InputGroup>
                <FormControl
                    placeholer="Search Stocks"
                />
                <InputGroup.Append>
                    <Button
                        type="button"
                        onClick={handleSearch}>
                        Search
                    </Button>
                </InputGroup.Append>
            </InputGroup>
        </div>
    )
}

export default StockSearch