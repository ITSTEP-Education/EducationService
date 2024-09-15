import { FC, useState, useEffect } from "react";
import axios from 'axios';
import { Display } from "../styles/General.styled";
import { TitleWrapper, BtnWrapper } from "../styles/ProductItem.styled";
import ProductOrder from "../ProductItem/ProductOrder";
import { dictNameToRoute } from "../ProductItem/ProductItemData";
import { TClientProperty } from '../ProductClient/ProductClient';


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

    const [isProductOrder, setIsProductOrder] = useState<boolean>(false);
    const [productOrder, setProductOrder] = useState<TProductItemOrder | null>({name:'none', typeEngeeniring:'none', timeStudy:0, sumPay:0});

    const handleIsProductOrder = () => {
        setIsProductOrder(!isProductOrder);
    }

    if(isProductOrder) {      
    
        const productOrderGet = axios.create({
            baseURL: 'https://localhost:7296/api/ProductItem',
            method: 'get',
            responseType: 'json',
        });
    
        let queryName = dictNameToRoute[props.nameProduct == null ? 'none' : props.nameProduct] == undefined ? props.nameProduct : dictNameToRoute[props.nameProduct == null ? 'none' : props.nameProduct];
     
        console.log(queryName);
        console.log(props._clientProperty);

        // useEffect(() => {
        //     productOrderGet.get(`productorder?name=${queryName}`)
        //     .then((responce) => {
                
        //         setProductOrder(responce.data);
        //     })
        //     .catch((error) => {
        //         console.log(error);
        //     });
        // }, []);
    };


    return(
        <div style={{width: `${props._width || 500}px`}}>
            <Display _justify='none'>
                <TitleWrapper style={{width:'450px', textAlign: 'center'}}>ORDER DETAILS</TitleWrapper>
                <BtnWrapper onClick={handleIsProductOrder}>SHOW</BtnWrapper>
            </Display>
            {isProductOrder? <ProductOrder _productOrder={productOrder}/> : <></>}
        </div>
    );
}

export default ProductOrderRecord;