
import React, { useState, useEffect } from 'react';

export function Categories() {
    const [existingData, setExistingData] = useState([{}]);
    const [newData, setNewData] = useState([{}]);
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
    const fetchCategoryData = async (data) => {
        await fetch('api/category/category',
            {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(data)
            }
        );
    };
    const addCategory = () => {
        const value = [...newData];
        value.push({ categoryName: data });
        setNewData(value);

        fetchCategoryData(data);
        setData('');
    };

    const handleExistingDataChange = event => {

    };
    const handleNewDataChange = event => {

    };

    const handleNewDataDelete = name => {
        setNewData(newData.filter(x => x.categoryName !== name));
    };
    const handleCostsChange = event => {

        const _tempData = event.target.value;

        setData(_tempData);
    };

    return (
        <div>
            <div>
                <input
                    name="categoryName"
                    data-id={1}
                    type="text"
                    value={data}
                    onChange={handleCostsChange}
                /><button onClick={addCategory}>+</button>
            </div>
            {
                isLoading ? (
                    <div>Loading ...</div >
                ) : (<div>
                    {newData.map((x, i) => {
                        if (!!x.categoryName == false) return;
                        return (
                            <div key={i}>
                                <input
                                    key={x.categoryId}
                                    name="categoryName"
                                    data-id={i}
                                    type="text"
                                    value={x.categoryName}
                                    onChange={handleNewDataChange}
                                /><button onClick={() => handleNewDataDelete(x.categoryName)} >-</button>
                            </div>
                        )
                    })}{
                        existingData.map((x, i) => (
                            <div key={i}>
                                <input
                                    key={x.categoryId}
                                    name="categoryName"
                                    data-id={i}
                                    type="text"
                                    value={x.categoryName}
                                    onChange={handleExistingDataChange}
                                />
                            </div>
                        ))}</div >
                    )}
        </div>
    )
}
