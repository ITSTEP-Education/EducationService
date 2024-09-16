import React, { FC, useState } from "react";
import { TypeOption, NameOption } from "../../ui/styled/OptionsProductItem.styled";
import { OptionsEducationWrap } from "../../ui/styled/OptionsEducation.styled";


type TInvitedPerson = {
    mainName: string,
    optionNames: Array<string>,
    _handleIsInvited: (e: React.FormEvent<HTMLElement>) => void,
}

const OptionsInvited: FC<TInvitedPerson> = (props) => {

    const [isActivities, setIsActivities] = useState<Array<boolean>>([true, false])

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
        props._handleIsInvited(e);
    }

    return(
        <OptionsEducationWrap>
            <TypeOption style={{width: '240px'}}>{props.mainName}</TypeOption>
            <NameOption title={props.optionNames[0]} isActive={isActivities[0]} onClick={(e) => {handleIsActivities(0, e)}}>{props.optionNames[0].toUpperCase()}</NameOption>
            <NameOption title={props.optionNames[1]} isActive={isActivities[1]} onClick={(e) => {handleIsActivities(1, e)}}>{props.optionNames[1].toUpperCase()}</NameOption>
        </OptionsEducationWrap>
    );
}

export default OptionsInvited;