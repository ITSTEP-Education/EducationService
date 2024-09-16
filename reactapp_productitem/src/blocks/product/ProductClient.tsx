import React, { FC, useState } from 'react';
import { ProductClientWrapper } from './ProductClient.styled';
import { TitleWrapper, BtnWrapper } from '../../ui/styled/ProductItem.styled';
import TabProductItemDto from '../../components/ProductItemDto/TabProductItemDto';
import ProductItemRecord from '../../components/ProductClientSections/ProductItemRecord';
import ProductOrderRecord from '../../components/ProductClientSections/ProductOrderRecord';
import OptionsEducation from '../../components/options/OptionsEducation';
import OptionsInvited from '../../components/options/OptionsInvited';
import { Display, BlockSpace } from '../../ui/styled/General.styled';
import { optionsForm, optionsPayMethod, optionsPayPeriod } from '../../contexts/ProductItemData';
import useInvited from '../../utils/useInvited';
import useEducationOptions from '../../utils/useEducationOptions';
import useNameProduct from '../../utils/useNameProduct';
import useEngineerType from '../../utils/useEngineertype';
import useBtnOnOff from '../../utils/useBtnOnOff';

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
   
   const [isTable, handleIsTable] = useBtnOnOff(false);
   const [isOptions, handleBtnOnOff] = useBtnOnOff(false);
   const [nameProduct, handleNameProduct] = useNameProduct(handleClientProps);
   const [engineerType, handleEngineerType] = useEngineerType(handleClientProps);
   
   const [isInvited, handleIsInvited] = useInvited(handleClientProps);
   const [educationForm, handleEducationForm] = useEducationOptions('daily', handleClientProps);
   const [payMethod, handlePayMethod] = useEducationOptions('cash', handleClientProps);
   const [payPeriod, handlePayPeriod] = useEducationOptions('full', handleClientProps);

   const [clientProperty, setClientProperty] = useState<TClientProperty | null>(null);
 
   return (
      <ProductClientWrapper>

         <div style={{width:'335px'}}>
            <Display _justify='none'>
               <TitleWrapper>EDUCATION SUBJECTS</TitleWrapper>
               <BtnWrapper onClick={handleIsTable}>{!isTable? 'LOAD' : 'UNLOAD'}</BtnWrapper>
            </Display>
            <TabProductItemDto isTableLoad={isTable} _handleNameProduct={handleNameProduct} _handleEngineerType={handleEngineerType}/>
         </div>
         <BlockSpace/>
         <ProductItemRecord _isOptions={isOptions} _nameProduct={nameProduct} _handleBtnSetUp={handleBtnOnOff}/>

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
