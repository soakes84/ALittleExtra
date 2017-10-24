import React, { Component } from 'react';
import { StaggeredMotion, spring } from 'react-motion';


const colors = [
   '#39f1c4',
   '#31ddb3',
   '#2ccba4'
]

const Box = (props) => {
   const styles = {
      flexBasis: `${props.width}%`,
      background: `${props.bgColor}`
   }
   return (
      <div className="box" style={styles}></div>
   )
}
const LoginWrapper = (props) => {
   return (
      <div className="columns small-12 main-bg grid-x align-center text-center">
        <h1 className="logo">a.LittlExtra</h1>
         <div className="header-content small-5 columns text-center">
            <p>Connecting Nonprofits with Local food Sources</p>
            <button className="button button-round">Login</button>
         </div>
      </div>
   )
}

export default class Login extends Component {
   render(){
      return(
         <StaggeredMotion
            defaultStyles={[
               { width: 100 },
               { width: 100 },
               { width: 100 },
            ]}
            styles={(prevStyles) =>
            [   { width: spring(0) },
               { width: spring(prevStyles[0].width) },
               { width: spring(prevStyles[1].width) }
            ]}

         >
               {(styles) => (
                  <div className="grid-y" style={{width: '100vw', height: '100vh', flexFlow: 'nowrap', flexDirection: 'column'}}>
                     <Box bgColor={colors[0]} width={styles[0].width} />
                     <Box bgColor={colors[1]} width={styles[1].width} />
                     <Box bgColor={colors[2]} width={styles[2].width} />
                     <LoginWrapper/>
                  </div>
               )}

         </StaggeredMotion>

      )
   }
}
