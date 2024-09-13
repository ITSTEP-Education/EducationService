import React, { FC, useState } from "react";
import { TypeOption, NameOption } from "../styles/OptionsProductItem.styled";

interface IOptionsEducation {

};

const OptionsEducation: FC<IOptionsEducation> = () => {

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

        handleValue(e);
    }

    const handleValue = (e: React.FormEvent<HTMLElement>):void => {
        console.log('default', e.currentTarget.title);
    };

    return(
        <div>
            <TypeOption>FORM</TypeOption>
            <NameOption title="daily" isActive={isActivities[0]} onClick={(e) => {handleIsActivities(0, e)}}>DAILY</NameOption>
            <NameOption title="holiday" isActive={isActivities[1]} onClick={(e) => {handleIsActivities(1, e)}}>HOLIDAY</NameOption>
            <NameOption title="remote" isActive={isActivities[2]} onClick={(e) => {handleIsActivities(2, e)}}>REMOTE</NameOption>
        </div>
    );
};

export default OptionsEducation;