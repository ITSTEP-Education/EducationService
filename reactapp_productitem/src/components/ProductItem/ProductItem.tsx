import React, { FC, useEffect, useState } from 'react';
import axios from 'axios';
import { TableWrapper } from '../ProductItemDto/TabProductItemDto.styled';
import '../ProductItemDto/TabProductItemDto.css';
import { dictNameToRoute } from './ProductItemData';

type NameProductItem = {
    nameProduct: string | null
}

type ProductItemProps = {
    id: number,
    name: string,
    description: string,
    typeEngeeniring: string,
    durationMonth: number,
    price: number
}

const recordProductItem = (product: ProductItemProps | null): React.ReactElement => (
    <tr>
        <td>{product?.id}</td>
        <td>{product?.name}</td>
        <td>{product?.description}</td>
        <td>{product?.typeEngeeniring}</td>
        <td>{product?.durationMonth}</td>
        <td>{product?.price}</td>
    </tr>
);

const ProductItem: FC<NameProductItem> = (props) => {

    const [productItem, setProductItem] = useState<ProductItemProps | null>(null);

    const productItemGet = axios.create({
        baseURL: 'https://localhost:7296/api/ProductItem',
        method: 'get',
        responseType: 'json',
    });

    let queryName = dictNameToRoute[props.nameProduct == null ? 'none' : props.nameProduct] == undefined ? props.nameProduct : dictNameToRoute[props.nameProduct == null ? 'none' : props.nameProduct]

    useEffect(() => {
        productItemGet.get(`productitem?name=${queryName}`)
        .then((responce) => {
            
            setProductItem(responce.data);
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

export default ProductItem;