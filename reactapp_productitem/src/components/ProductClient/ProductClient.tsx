import React, { FC, useEffect, useState } from 'react';
import { ProductClientWrapper } from './ProductClient.styled';
import { TitleWrapper, BtnWrapper } from '../styles/ProductItem.styled';
import TabProductItemDbo from '../TabProductItemDbo/TabProductItemDbo';
import { Display } from '../styles/General.styled';
import axios from 'axios';

interface ProductClientProps {}

export interface IProductItemDto{
   id: number,
   name: string,
   typeEngeeniring: string,
}

const ProductClient: FC<ProductClientProps> = (): React.FunctionComponentElement<ProductClientProps> => {

   const [productsItemDbo, setProductsItemDbo] = useState<Array<IProductItemDto | null>>([]);
   const [isTable1, setIsTable1] = useState(false);

   const handleBtnLoad = (e: React.FormEvent<HTMLElement>): void => {

      e.preventDefault();

      const productsDbo = axios.create({
         baseURL: 'https://localhost:7296/api/ProductItem/',
         method: 'get',
         responseType: 'json',
      });
       
      productsDbo.get('all-productitems-dto').
      then((responce) => {

         setProductsItemDbo(responce.data);
         for(let product of productsItemDbo){
            console.log(product);
         }

         setIsTable1(true);
      }).
      catch((error) => {
         console.log('error:', error)
      });
   }

   useEffect(() => {handleBtnLoad}, [productsItemDbo]);

   return (
      <ProductClientWrapper>
        <div style={{width: '350px'}}>
           <Display _justify='none'>
              <TitleWrapper>Table 1. ProductItem (DTO)</TitleWrapper>
              <BtnWrapper onClick={handleBtnLoad}>LOAD</BtnWrapper>
           </Display>
           {isTable1? <TabProductItemDbo productsDto={productsItemDbo}/> : <></>}
        </div>
      </ProductClientWrapper>
     );
}

export default ProductClient;
