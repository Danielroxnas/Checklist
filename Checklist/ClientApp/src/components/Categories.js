
import React, { useState, useEffect } from 'react';

export function Categories() {
    const [existingData, setExistingData] = useState([{}]);
    const [data, setData] = useState('');
    const [isLoading, setIsLoading] = useState(true);

    useEffect(() => {
        const fetchData = async () => {
            setIsLoading(true);
            const response = await fetch('api/category/AllCategories');
            const result = await response.json();
            setExistingData(result);
            setIsLoading(false);
        };

        fetchData();
    }, []);

    const addCategory = () => {
        const value = [...existingData];
        value.push({ categoryName: data });
        setExistingData(value);
    };
    const handleCostsChange = event => {

        const _tempData = event.target.value;

        setData(_tempData);
    }; const handleCostsChange1 = event => {

    };
    return (
        <div>
            <div>
                <input
                    name="categoryName"
                    data-id={1}
                    type="text"
                    onChange={handleCostsChange}
                />
                <div className="table-row">
                    <div className="table-data">
                        <button onClick={addCategory}>+</button>
                    </div>
                </div>
            </div>
            {
                isLoading ? (
                    <div>Loading ...</div >
                ) : (
                        existingData.map((x, i) => (
                            <div key={i}>
                                <input
                                    key={x.categoryId}
                                    name="categoryName"
                                    data-id={i}
                                    type="text"
                                    value={x.categoryName}
                                    onChange={handleCostsChange1}
                                />
                            </div>
                        ))
                    )}

        </div>
    )
}
