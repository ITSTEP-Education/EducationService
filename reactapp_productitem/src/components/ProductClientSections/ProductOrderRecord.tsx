import { FC, useState, useEffect } from "react";
import axios from 'axios';
import { Display } from "../../ui/styled/General.styled";
import { TitleWrapper, BtnWrapper } from "../../ui/styled/ProductItem.styled";
import ProductOrder from "../ProductItem/ProductOrder";
import { dictNameToRoute } from "../../contexts/ProductItemData";
import { TClientProperty } from '../../blocks/product/ProductClient';


interface IProductOrderRecord{
    _width?: number,
    nameProduct: string | null,
    _clientProperty: TClientProperty | null,
}

type TProductItemOrder = {
    name: string,
    typeEngeeniring: string,
    timeStudy: number,
    sumPay: number,
}

const ProductOrderRecord: FC<IProductOrderRecord> = (props) => {

    const [productOrder, setProductOrder] = useState<TProductItemOrder | null>({name:'none', typeEngeeniring:'none', timeStudy:0, sumPay:0});

    const handleProductOrder = () => {

        const productOrderPost = axios.create({
            baseURL: 'https://localhost:7296/api/ProductItem',
            method: 'post',
            responseType: 'json',
            headers:{
                'Content-Type': 'application/json'
            }
        });
    
        let queryName = dictNameToRoute[props.nameProduct == null ? 'none' : props.nameProduct] == undefined ? props.nameProduct : dictNameToRoute[props.nameProduct == null ? 'none' : props.nameProduct];

        productOrderPost.post(`productorder?name=${queryName}`,  props._clientProperty)
        .then((responce) => {           
            setProductOrder(responce.data);
        })
        .catch((error) => {
            console.log(error);
            setProductOrder(null);
        });       

        // console.log(props._clientProperty);
    }

    useEffect(handleProductOrder, [props.nameProduct, props._clientProperty]);

    return(
        <div style={{width: `${props._width || 500}px`}}>
            <Display _justify='none'>
                <TitleWrapper style={{width:'450px', textAlign: 'center'}}>ORDER DETAILS</TitleWrapper>
                <BtnWrapper onClick={handleProductOrder} disabled={true}>SHOW</BtnWrapper>
            </Display>
            <ProductOrder _productOrder={productOrder}/>
        </div>
    );
}

export default ProductOrderRecord;