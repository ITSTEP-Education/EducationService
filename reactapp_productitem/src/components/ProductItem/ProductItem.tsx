import React, { FC, useEffect, useState } from 'react';
import axios from 'axios';
import { TableWrapper } from '../ProductItemDto/TabProductItemDto.styled';
import '../ProductItemDto/TabProductItemDto.css'

type NameProductItem = {
    nameProduct: string | null
}

type ProductItem = {
    id: number,
    name: string,
    description: string,
    typeEngeeniring: string,
    durationMonth: number,
    price: number
}

const recordProductItem = (product: ProductItem | null): React.ReactElement => (
    <tr>
        <td>{product?.id}</td>
        <td>{product?.name}</td>
        <td>{product?.description}</td>
        <td>{product?.typeEngeeniring}</td>
        <td>{product?.durationMonth}</td>
        <td>{product?.price}</td>
    </tr>
);

const RecordProductItem: FC<NameProductItem> = (props) => {

    const [productItem, setProductItem] = useState<ProductItem | null>(null);

    const productItemGet = axios.create({
        baseURL: 'https://localhost:7296/api/ProductItem',
        method: 'get',
        responseType: 'json',
    });

    useEffect(() => {
        productItemGet.get(`productitem?name=${props.nameProduct}`)
        .then((responce) => {
            setProductItem(responce.data);
            console.log(productItem);
        })
        .catch((error) => {
            console.log(error);
        });
    }, [props.nameProduct]);

    return(
    <TableWrapper id='tab-dbo'>
        <tr>
            <th>id</th>
            <th>Name</th>
            <th>Description</th>
            <th>Type</th>
            <th>Months, qty</th>
            <th>Price, UAH</th>
        </tr>
        {recordProductItem(productItem)}
    </TableWrapper>
    );
}

export default RecordProductItem;