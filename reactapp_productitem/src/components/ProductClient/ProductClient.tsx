import React, { FC, useEffect, useState } from 'react';
import { ProductClientWrapper } from './ProductClient.styled';
import { TitleWrapper, BtnWrapper } from '../styles/ProductItem.styled';
import TabProductItemDto from '../ProductItemDto/TabProductItemDto';
import ProductItemRecord from '../ProductClientSections/ProductItemRecord';
import ProductOrderRecord from '../ProductClientSections/ProductOrderRecord';
import OptionsEducation from '../ProductClientSections/OptionsEducation';
import OptionsInvited from '../ProductClientSections/OptionsInvited';
import { Display, BlockSpace } from '../styles/General.styled';
import { optionsForm, optionsPayMethod, optionsPayPeriod } from '../ProductItem/ProductItemData';


interface ProductClientProps {}

export type TClientProperty = {
   cltTimeProps: {
      educationForm: string,
      engineerType: string,
   },
   cltPayProps: {
      isInvitedPerson: boolean,
      payMethod: string,
      payPeriod: string,
   }
}

const ProductClient: FC<ProductClientProps> = (): React.FunctionComponentElement<ProductClientProps> => {

   const [isTableLoad, setIsTable1] = useState<boolean>(false);
   const [isOptions, setIsOptions] = useState<boolean>(false);
   const [nameProduct, setNameProduct] = useState<string | null>(null);
   const [educationForm, setEducationForm] = useState<string>('daily');
   const [engineerType, setEngineerType] = useState<string | null>('');
   const [isInvited, setIsInvited] = useState<boolean>(true);
   const [payMethod, setPayMethod] = useState<string>('cash');
   const [payPeriod, setPayPeriod] = useState<string>('full');

   const [clientProperty, setClientProperty] = useState<TClientProperty | null>({
      cltTimeProps:{
         educationForm: educationForm,
         engineerType: engineerType != null? engineerType : 'none',
      }, cltPayProps:{
         isInvitedPerson: isInvited,
         payMethod: payMethod,
         payPeriod: payPeriod,
      }
   });

   const handleBtnLoad = (e: React.FormEvent<HTMLElement>): void => {
      e.preventDefault();
      setIsTable1(true);
   }

   const handleBtnSetUp = (e: React.FormEvent<HTMLElement>): void => {
      e.preventDefault();
      setIsOptions(!isOptions);
   }

   const handleNameProduct = (e: React.FormEvent<HTMLElement>): void => {
      e.preventDefault();
      setNameProduct(e.currentTarget.getElementsByTagName('td')[1].textContent);
   }

   const handleEducationForm = (e: React.FormEvent<HTMLElement>): void => {
      e.preventDefault();

      setEducationForm(e.currentTarget.title);
      handleClientProps();
   }
   
   const handleEngineerType = (e: React.FormEvent<HTMLElement>): void => {
      e.preventDefault();
    
      setEngineerType(e.currentTarget.getElementsByTagName('td')[2].textContent);
      handleClientProps();
   }

   const handleIsInvited = (e: React.FormEvent<HTMLElement>): void => {
      e.preventDefault();

      setIsInvited(e.currentTarget.textContent?.toLocaleLowerCase() == 'yes');
      handleClientProps();
   }

   const handlePayMethod = (e: React.FormEvent<HTMLElement>): void => {
      e.preventDefault();

      setPayMethod(e.currentTarget.title);
      handleClientProps();
   }

   const handlePayPeriod = (e: React.FormEvent<HTMLElement>): void => {
      e.preventDefault();

      setPayPeriod(e.currentTarget.title);
      handleClientProps();
   }

   const handleClientProps = () => {
      setClientProperty({
         cltTimeProps:{
            educationForm: educationForm,
            engineerType: engineerType != null? engineerType : 'none',
         }, cltPayProps:{
            isInvitedPerson: isInvited,
            payMethod: payMethod,
            payPeriod: payPeriod,
         }
      });
   }

   return (
      <ProductClientWrapper>

         <div style={{width:'335px'}}>
            <Display _justify='none'>
               <TitleWrapper>EDUCATION SUBJECTS</TitleWrapper>
               <BtnWrapper onClick={handleBtnLoad}>LOAD</BtnWrapper>
            </Display>
            <TabProductItemDto isTableLoad={isTableLoad} _handleNameProduct={handleNameProduct} _handleEngineerType={handleEngineerType}/>
         </div>
         <BlockSpace/>
         <ProductItemRecord _nameProduct={nameProduct} _handleBtnSetUp={handleBtnSetUp}/>

         <div style={{width:'500px', display: isOptions? 'block' : 'none', textAlign:'center'}}>
            <BlockSpace/>
            <TitleWrapper style={{backgroundColor: '#6992b8'}}>EDUCATION OPTIONS</TitleWrapper>
            <OptionsEducation mainName='FORM' optionNames={optionsForm} _handleEducationForm={handleEducationForm}/>
            <OptionsEducation mainName='METHOD' optionNames={optionsPayMethod} _handleEducationForm={handlePayMethod}/>
            <OptionsEducation mainName='PERIOD' optionNames={optionsPayPeriod} _handleEducationForm={handlePayPeriod}/>

            <BlockSpace/>
            <TitleWrapper style={{backgroundColor: '#6992b8'}}>ADDITIONAL OPTIONS</TitleWrapper>
            <OptionsInvited mainName='INVITED PERSON' optionNames={['yes', 'no']} _handleIsInvited={handleIsInvited}/>
         </div>
         <BlockSpace/>
         {isOptions? <ProductOrderRecord nameProduct={nameProduct} _clientProperty={clientProperty}/> : <></>}

      </ProductClientWrapper>
     );
}

export default ProductClient;
