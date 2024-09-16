import React, { FC, useState } from "react";
import { TypeOption, NameOption } from "../../ui/styled/OptionsProductItem.styled";
import { OptionsEducationWrap } from "../../ui/styled/OptionsEducation.styled";

interface IOptionsEducation {
    mainName: string,
    optionNames: Array<string>,
    _handleEducationForm: (e: React.FormEvent<HTMLElement>) => void,
};

const OptionsEducation: FC<IOptionsEducation> = (props) => {

    const [isActivities, setIsActivities] = useState<Array<boolean>>([true, false, false])

    const handleIsActivities = (index: number, e: React.FormEvent<HTMLElement>):void => {
        const nextIsActivities = isActivities.map((c, i)=> {
            if(i == index){
                return c = true;
            }
            else{
                return false;
            }
        });

        setIsActivities(nextIsActivities);
        props._handleEducationForm(e);
    }

    return(
        <OptionsEducationWrap>
            <TypeOption>{props.mainName}</TypeOption>
            <NameOption title={props.optionNames[0]} isActive={isActivities[0]} onClick={(e) => {handleIsActivities(0, e)}}>{props.optionNames[0].toUpperCase()}</NameOption>
            <NameOption title={props.optionNames[1]} isActive={isActivities[1]} onClick={(e) => {handleIsActivities(1, e)}}>{props.optionNames[1].toUpperCase()}</NameOption>
            <NameOption title={props.optionNames[2]} isActive={isActivities[2]} onClick={(e) => {handleIsActivities(2, e)}}>{props.optionNames[2].toUpperCase()}</NameOption>
        </OptionsEducationWrap>
    );
};

export default OptionsEducation;